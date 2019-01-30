using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestScript : MonoBehaviour
{

    public Text text;
    public Text QuestDesc;

    public bool IsTheQuestEnded = false;
    public bool firstStepEnded = false;
    public Canvas canvas;
    private string[] dialog = {
        "[Łysy] Siemano, musisz mi pomóc?",
        "[Ja] Czego ?!",
        "[Lysy] Obok jeziora stacjonuje moja koleżanka, rozbiłem samochód i potrzebuję pomocy, ona ma ciężki sprzęt, napewno mi pomoże. Czy mógłbyś ją znaleźć?",
        "[Ja] No, spoko!",
        "[Łysy] Super! Sprowadź ją jak najszybciej bo jestem już wyczerpany!",
    };
    public int numer = 0;
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
        if (!firstStepEnded)
        {
            canvas.enabled = true;
            StartCoroutine(DisplayTimer());
            //Debug.Log("Otworzyl NPC");
        }

    }


    IEnumerator DisplayTimer()
    {
        while (numer != 5)
        {
            string word = dialog[numer];
            Debug.Log(word);
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
        firstStepEnded = true;
        canvas.enabled = false;
        text.text = "";
        QuestDesc.enabled = true;
        yield return new WaitForSeconds(3f);
        QuestDesc.enabled = false;
    }





}
