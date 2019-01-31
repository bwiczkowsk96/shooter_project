using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestScript : MonoBehaviour
{

    public Text text;
    public Text QuestDesc;
    public Text QuestDesc2;
    public Text Cash;

    public int wallet;
    public bool FoundCash = false;
    public bool IsTheQuestEnded = false;
    public bool firstStepEnded = false;
    public bool secoundStepEnded = false;
    public bool thirdStepEnded = false;
    public Canvas canvas;

    public BoxCollider collider;
    public GameObject gold;
    public GameObject car;
    public GameObject car2;

    public int numberOfDialog = 0;

    private string[] textQuest =
    {
        "Sprowadź pomoc łysemu !",
        "Przynieś do Izzy kasę spod auta na dzielinicy Łysego",
        "Idź do Łysego",
        "Wróć do łysego niebawem!",
    };
    private string[] dialog = {
        "[Łysy] Siemano, musisz mi pomóc?",
        "[Ja] Czego ?!",
        "[Lysy] Obok jeziora stacjonuje moja koleżanka, rozbiłem samochód i potrzebuję pomocy, ona ma ciężki sprzęt, napewno mi pomoże. Czy mógłbyś ją znaleźć?",
        "[Ja] No, spoko!",
        "[Łysy] Super! Sprowadź ją jak najszybciej bo jestem już wyczerpany!",
    };
    private string[] dialog2 =
    {
        "[Izzy] Cześć, czego tu szukasz ?!",
        "[Ja] Łysy Cię szuka, rozwalił brykę. Powiedział, że jesteś w stanie mu pomoc!",
        "[Izzy] Ja mam mu pomagać?! Ciekawe z jakiej paki.. hmmm..",
        "[Izzy] Ale dobra.. mam pomysł.. jeden gość siedzi mi hajs, znajdź go i odbierz co moje",
        "[Izzy] ee czekaj.. przecież ten typ wpadł i zawineli go za kraty.. ale..",
        "[Izzy] Słyszałam, że jego kumpel wychlapał, że podobno kase ukrył w kole jakiegoś samochodu koło Łysego chaty.",
        "[Izzy] Jak mi przyniesiesz to pomogę Łysemu, umowa stoi ?!",
        "[Ja] Nie ukrywam, że potrzebuje kasy wiec za szfędanie się po tej dzielnicy coś byś odpaliła co..?",
        "[Izzy] Pazerny jesteś, ale w porządku coś Ci rzucę",
        "[Ja] W takim razie lece szukać tej kasy!",
    };

    private string[] dialog3 =
    {
        "[Izzy] Oooo masz moją kase! Super ! Masz tu swoją dole i spadaj! ",
        "[Ja] Pamietasz, że obiecałaś jeszcze pomóc Łysemu?",
        "[Izzy] Tak tak, nie zdązysz wrócić na dzielnie a jego auto bedzie już na kołach",
    };

    private string[] dialog4 =
    {
        "[Łysy] Patrz, stoi fura ! Dzięki wielkie!",
        "[Ja] Zdajesz sobie sprawe, że za dzięki nikt dzieci nie wykarmil ?",
        "[Łysy] Dobra dobra masz tu trochę ale odezwij się nie długo będę miał dla Ciebie kilka propozycji!",
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
        if(numberOfDialog == 1)
        {
            canvas.enabled = true;
            dialog = dialog2;
            
            StartCoroutine(DisplayTimer());
            secoundStepEnded = true;
            gold.SetActive(true);
        }
        if (numberOfDialog == 0 && !firstStepEnded && numberOfDialog == 0)
        {
            canvas.enabled = true;
            StartCoroutine(DisplayTimer());
            collider.enabled = false;
            
        }
        if(!thirdStepEnded && FoundCash && numberOfDialog == 2)
        {
            canvas.enabled = true;
            dialog = dialog3;
           
            StartCoroutine(DisplayTimer());
            thirdStepEnded = true;
            Object.Destroy(car);
            car2.SetActive(true);
            collider.enabled = true;
            wallet += 100;
            Cash.text = "$" + wallet.ToString();


        }
        if(thirdStepEnded && numberOfDialog == 3)
        {
            canvas.enabled = true;
            dialog = dialog4;

            StartCoroutine(DisplayTimer());
            wallet += 100;
            Cash.text = "$" +  wallet.ToString();
            collider.enabled = false;
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
        firstStepEnded = true;
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
