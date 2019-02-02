using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour {
    public Text hp;
    public Text ammo;
    public Text wallet;
    
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hp.text = "HP: " + PlayerPrefs.GetFloat("health").ToString();
        wallet.text = "$: " + PlayerPrefs.GetInt("wallet").ToString();
        ammo.text = PlayerPrefs.GetInt("currentClip").ToString()+"/"+ PlayerPrefs.GetInt("currentAmmo").ToString();
        
    }
}
