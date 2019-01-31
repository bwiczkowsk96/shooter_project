using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCoin : MonoBehaviour {
    public Text text;
    public QuestScript quest;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        Object.Destroy(this.gameObject);
        text.text = "Znalazłeś kase leć do Izzy!";
        quest.FoundCash = true;

    }
}
