using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour {
    public Text health;
    private float currentHealth = 100;
    private float maxHealth = 100;
    void Awake()
    {
        PlayerPrefs.SetFloat("health", currentHealth);
    }
	// Use this for initialization
	void Start () {
        
       
    }
	
	// Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            takeHit(30);
        }
    }

    void takeHit(float damage)
    {
        currentHealth -= damage;
        PlayerPrefs.SetFloat("health", currentHealth);



    }
}
