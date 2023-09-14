using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
using UnityEngine.UI;
using TMPro;


public class GuessJudeteLogic : MonoBehaviour
{

    public TextAsset resedinteJudete;
    string[] listaResJud = new string[41]; 
    public string currJudName;
    public int currLevel = 1,currScore = 0 ;
    public int currentGuess = 0;

    public float time = 0f;
    public struct judRes
    {
       public int id;
       public string judet;
       public bool used;
    };

    public string temp;
    public judRes[] lista = new judRes[41];
    List<judRes> remaining = new List<judRes>();
    int nr = 0 ;

    public GameObject winning;
    GameObject[] jud;
    GameObject[] btns;
    System.Random rand = new System.Random(); 

    public void JudeteReset()
    {
        winning.SetActive(false);
        jud = GameObject.FindGameObjectsWithTag("btns");
        for(int i = 0 ; i < GameObject.Find("Judete").transform.childCount;i++){jud[i].GetComponent<RawImage>().color = Color.white;lista[i].used = true;}
        jud = GameObject.FindGameObjectsWithTag("buttons");
        for(int i = 0 ; i < GameObject.Find("Judete").transform.childCount;i++){jud[i].GetComponent<Button>().enabled = true ;}
    }

    public void JudetePause(bool val)
    {
        jud = GameObject.FindGameObjectsWithTag("buttons");
        for(int i = 0 ; i < GameObject.Find("Judete").transform.childCount;i++)jud[i].GetComponent<Button>().enabled = val;
    }

    public void JudeteDecision()
    {
        winning.SetActive(true);
        GameObject.Find("btnBack").GetComponent<Button>().enabled = false ;
        GameObject.Find("lblScore").GetComponent<TMP_Text>().text = "Completed: " + (currScore / (41*3f) *100f ).ToString("0.00")+"%";
        jud = GameObject.FindGameObjectsWithTag("buttons");
        for(int i = 0 ; i < GameObject.Find("Judete").transform.childCount;i++)jud[i].GetComponent<Button>().enabled = false;
        PlayerPrefs.SetInt("xp",PlayerPrefs.GetInt("xp") + currScore*2);
        GameObject.Find("lblXp").GetComponent<TMP_Text>().text = "+"+ (currScore*2).ToString()+ " XP";
        Debug.Log("xp " + PlayerPrefs.GetInt("xp"));
        PlayerPrefs.SetInt("counter", PlayerPrefs.GetInt("counter")+1);
        GameObject.Find("Font").GetComponent<References>().launchAds();
    }

    public void JudeteLogic()
    {
        if(currLevel == 42){JudeteDecision();return;}
        //if(currLevel >= 40){foreach(judRes item in lista)Debug.Log(item.id.ToString() + " " + item.used.ToString());}
        //currentGuess = rand.Next(0,40);
        remaining.Clear();
        foreach(judRes item in lista)if(item.used)remaining.Add(item);

        currentGuess = rand.Next(0,remaining.Count-1);
        currentGuess = remaining[currentGuess].id-1;
       // Debug.Log("working " + currentGuess);
        currJudName = lista[currentGuess].judet;
        lista[currentGuess].used = false;
        //GameObject.Find("Buttons").transform.GetChild(currentGuess).GetComponent<ButtonJudeteInt>().newGuess();
        if(PlayerPrefs.GetInt("language") % 2 == 0)
        GameObject.Find("lblQuestion").GetComponent<TMP_Text>().text = "Unde se afla judetul: " + currJudName + "?";
        else
        GameObject.Find("lblQuestion").GetComponent<TMP_Text>().text = "Where is placed: " + currJudName + "?";
    }


   public void JudeteRead()
   {
        currLevel = 1; 
        currScore = 0;
        winning.SetActive(false);
        GameObject.Find("btnBack").GetComponent<Button>().enabled = true ;
        if(!PlayerPrefs.HasKey("score"))PlayerPrefs.SetInt("score",3);
        else PlayerPrefs.SetInt("score",3);
        if(nr != 0) {JudeteLogic();return;}

        listaResJud = resedinteJudete.text.Split(new string[] {"\n"}, System.StringSplitOptions.None);
        foreach(string elem in listaResJud)
        {
            nr++;
            temp = "";
            int i = 0 ;
            while(elem[i] != ' ')i++;
            i++;
            while(elem[i] != ' ')i++;
            i++;
            lista[nr-1].id = nr; 
            while(elem[i] != ' '){if(elem[i] != '@')temp+=elem[i];else temp+= ' ';i++;}
            i++;
            lista[nr-1].judet = temp;
            
            lista[nr-1].used = true;
           //Debug.Log(lista[nr-1].id.ToString() + " " + lista[nr-1].judet );
        }
        jud = GameObject.FindGameObjectsWithTag("buttons");
        foreach(GameObject obj in jud)obj.GetComponent<Button>().enabled = true;
        JudeteLogic();
   }


    

    


    void Start()
    {
        btns = GameObject.FindGameObjectsWithTag("buttons");
        Input.simulateMouseWithTouches = true ;
    }

    // Update is called once per frame
    
    void Update()
    {
        if(time > 0f)
        {
            time -= Time.deltaTime;
            foreach(GameObject tr in btns)tr.GetComponent<Button>().enabled = false ;
            Debug.Log(time);
        }
        else
        {
            foreach(GameObject tr in btns)tr.GetComponent<Button>().enabled = true ;
        }

        
    }
}
