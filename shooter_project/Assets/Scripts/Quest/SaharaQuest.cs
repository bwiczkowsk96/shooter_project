using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaharaQuest : MonoBehaviour {

    public Text text;
    public Text QuestDesc;
    public Text QuestDesc2;
    public Text Cash;

   
    public bool FoundCash = false;
    public bool IsTheFirstQuestEnded = false;
    
    public Canvas canvas;

   
    
    public GameObject helicopter;

    public int numberOfDialog = 0;

    private string[] textQuest =
    {
        "Pokonaj barbarzyńców i zdobąć skrzynie !",
       
    };
    private string[] dialog = {
        "[Zdrajca] Witaj, Łysy mówił że przyleci jakiś kozak.",
        "[Ja] Gdzie skrzynia? Coś powinienem wiedzieć ?",
        "[Zdrajca] Skrzynia jest na końcu jeziora pod drzewami, ale uważaj bo strzeże jej pełno barbarzyńców..",
        "[Ja] Spokojnie zaaopatrzyłem się w helikopterze w 10 magazynków do mojej Beretki !",
        "[Zdrajca] No to dobrze! Ja musze stąd uciekać bo jestem tu nie mile widziany",
        "[Zdrajca] Rozlicze się już z Łysym, powodzenia kolego !"
    };
  

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnTriggerEnter(Collider col)
    {
        if (numberOfDialog == 0)
        {
            canvas.enabled = true;
            

            StartCoroutine(DisplayTimer());
           
        }
    }

    public int numer = 0;
    IEnumerator DisplayTimer()
    {

        numer = 0;
        while (numer != dialog.Length)
        {
            string word = dialog[numer];

            for (int i = 0; i < word.Length; i++)
            {
                text.text += word[i].ToString();
                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(0.5f);
            text.text = "";

            numer++;
        }
        yield return new WaitForSeconds(1f);
      
        canvas.enabled = false;
        text.text = "";
        QuestDesc.enabled = true;
        QuestDesc.text = textQuest[numberOfDialog];
        yield return new WaitForSeconds(3f);
        QuestDesc.enabled = false;
        QuestDesc.text = "";
        QuestDesc2.text = textQuest[numberOfDialog];
        numberOfDialog++;
    }





}
