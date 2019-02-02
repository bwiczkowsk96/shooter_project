using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSahara : MonoBehaviour {
    public bool LoadedSahara = false;
  
    public string sceneName;
    // Use this for initialization
    void Start () {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(sceneName == "sahara")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            PlayerPrefs.SetInt("secondQuest", 1);
        }
        else
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
   
}
