using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour {
    public Text QuestDesc;
    public Text QuestDesc2;

    public GameObject helicopter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        
       
        if(col.gameObject.tag == "Player")
        {

       
        helicopter.transform.Translate(0, -33, 0);
       
        
        QuestDesc2.text = "Helikopter już na Ciebie czeka!";
        Destroy(this.gameObject);
        }
    }

   
}
