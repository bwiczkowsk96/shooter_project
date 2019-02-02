using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Shooting2 : MonoBehaviour
{
    public Texture2D crosshairTexture;
    public AudioClip pistolShot;
    public AudioClip reloadSound;
    public int maxAmmo = 200;
    public int clipSize = 10;
    public Text ammoText;
    public Text reloadText;
    public float reloadTime = 3.0f;
    public bool automatic = false;
    public float shotDelay = 0.5f;
    public GameObject bulletHole;
    public GameObject bloodParticles;
    public float demage = 5.0f;


    private int currentAmmo = 100;
    private int currentClip;
    private Rect position;
    private float range = 200.0f;
    public ParticleSystem pistolSparks;
    private Vector3 fwd;
    private RaycastHit hit;
    private bool isReloading = false;
    private float shotDelayCounter = 0.0f;
    private float zoomFieldOfView = 40.0f;
    private float defaultFieldOfView = 60.0f;

    public Joybutton fire;
    
    

    private float timer = 0.0f;

    void Start()
    {
        position = new Rect((Screen.width - crosshairTexture.width) / 2,
                              (Screen.height - crosshairTexture.height) / 2,
                              crosshairTexture.width,
                              crosshairTexture.height);


        GetComponent<AudioSource>().clip = pistolShot;
        currentClip = clipSize;
        PlayerPrefs.SetInt("currentClip", currentClip);
        PlayerPrefs.SetInt("currentAmmo", currentAmmo);
    }

    void Update()
    {
        
        if (shotDelayCounter > 0)
        {
            shotDelayCounter -= Time.deltaTime;
        }
        Transform tf = transform.parent.GetComponent<Transform>();
        fwd = tf.TransformDirection(Vector3.forward);

        if (((fire.Pressed && currentClip == 0) || Input.GetButtonDown("Reload")) && currentClip < clipSize)
        {
            if (currentAmmo > 0)
            {
                GetComponent<AudioSource>().clip = reloadSound;
                GetComponent<AudioSource>().Play();
                isReloading = true;
            }
        }

        if (isReloading)
        {
            timer += Time.deltaTime;
            if (timer >= reloadTime)
            {
                int needAmmo = clipSize - currentClip;

                if (currentAmmo >= needAmmo)
                {
                    currentClip = clipSize;
                    currentAmmo -= needAmmo;
                    PlayerPrefs.SetInt("currentAmmo", currentAmmo);
                }
                else
                {
                    currentClip += currentAmmo;
                    currentAmmo = 0;
                    PlayerPrefs.SetInt("currentAmmo", currentAmmo);
                }

                GetComponent<AudioSource>().clip = pistolShot;
                isReloading = false;
                timer = 0.0f;
            }
        }

        if (currentClip > 0 && !isReloading)
        {
            if ((fire.Pressed || (fire.Pressed && automatic)) && shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                GetComponent<AudioSource>().Play();
                pistolSparks.Play();
                currentClip--;
                PlayerPrefs.SetInt("currentClip", currentClip);

                if (Physics.Raycast(tf.position, fwd, out hit))
                {
                    if (hit.transform.tag.Equals("Enemy") && hit.distance < range)
                    {
                        hit.transform.gameObject.SendMessage("takeHit", demage);
                        GameObject go;
                        go = Instantiate(bloodParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)) as GameObject;
                        Destroy(go, 0.3f);
                    }
                   
                }
            }
        }

        if (gameObject.GetComponentInParent<Camera>() is Camera)
        {
            Camera cam = gameObject.GetComponentInParent<Camera>();
            if (Input.GetButton("Fire2"))
            {
                if (cam.fieldOfView > zoomFieldOfView)
                {
                    cam.fieldOfView--;
                }
            }
            else
            {
                if (cam.fieldOfView < defaultFieldOfView)
                {
                    cam.fieldOfView++;
                }
            }
        }

    }

    void OnGUI()
    {
        GUI.DrawTexture(position, crosshairTexture);
        


    }

    void addAmmo(Vector2 data)
    {
        int ammoToAdd = (int)data.x;

        if (maxAmmo - currentAmmo >= ammoToAdd)
        {
            currentAmmo += ammoToAdd;
        }
        else
        {
            currentAmmo = maxAmmo;
        }
    }

    public bool canGetAmmo()
    {
        if (currentAmmo == maxAmmo)
        {
            return false;
        }
        return true;
    }

}