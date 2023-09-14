using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
using UnityEngine.UI;
using TMPro;
public class ResedinteGameLogic : MonoBehaviour
{

    public bool gameMode = false;

    public GameObject winning;
    
    public Texture[] imgJud;
    public TextAsset resedinteJudete;
    string[] listaResJud = new string[40]; 

    public string currJudName;

    GameObject btn1, btn2, btn3, btn4 ;

    public int currLevel = 1,currScore = 0 ;
    public int currentGuess = 0;
    int currPosition=0, pos=  0;

    public float time = 0f;
    public struct judRes
    {
       public int id;
       public string judet;
       public string resedinta; 
       public bool used;
    };
    public string temp;
    public judRes[] lista = new judRes[41];
    List<judRes> remaining = new List<judRes>();
    int nr = 0 ;

    System.Random rand = new System.Random(); 

    public void Decision()
    {
        PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + currScore * 5);
        for(int j = 1 ; j< 5 ; j++)
        {
            GameObject.Find("btnOption"+j.ToString()).transform.GetChild(0).GetComponent<TMP_Text>().text = "";
            GameObject.Find("btnOption"+j.ToString()).GetComponent<Button>().enabled = false ;
        }
        GameObject.Find("lblQuestion").GetComponent<TMP_Text>().text = "Ai terminat: "+currScore.ToString() + "/10";
            winning.SetActive(true);
            winning.transform.GetChild(2).GetComponent<TMP_Text>().text = "Score " + currScore.ToString() + "/10";
        PlayerPrefs.SetInt("counter", PlayerPrefs.GetInt("counter")+1);
        GameObject.Find("Font").GetComponent<References>().launchAds();
        GameObject.Find("lblXp").GetComponent<TMP_Text>().text = "+"+ (currScore*5).ToString()+ " XP";
    }
    public void resJudeteReadFile()
    {
        currLevel = 1; 
        currScore = 0;
        if(nr != 0){
            for(int j = 1 ; j< 5 ; j++)
            {
            GameObject.Find("btnOption"+j.ToString()).transform.GetChild(0).GetComponent<TMP_Text>().text = "";
            GameObject.Find("btnOption"+j.ToString()).GetComponent<Button>().enabled = true ;
            
            }
            for(int j = 0 ; j <41 ; j++)lista[j].used = true ;
            ResJudGameLogic();
            return;}

        btn1 =GameObject.Find("btnOption1");
        btn2 =GameObject.Find("btnOption2");
        btn3 =GameObject.Find("btnOption3");
        btn4 =GameObject.Find("btnOption4");

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
            temp = ""; 
             while(elem[i] != ','){if(elem[i] != '@')temp+=elem[i];else temp+= ' ';i++;}
            i++;
            lista[nr-1].resedinta = temp ;
            lista[nr-1].used = true;
            Debug.Log(lista[nr-1].id.ToString() + " " + lista[nr-1].judet + " " +  lista[nr-1].resedinta);
        }
        ResJudGameLogic();
        
    }

    public void ResJudGameLogic()
    {
            if(currLevel == 11){Decision();return;}
            ColorBlock cb = GameObject.Find("btnOption1").transform.GetComponent<Button>().colors;
            cb.normalColor = Color.white;
            remaining.Clear();
            foreach(judRes item in lista)if(item.used)remaining.Add(item);
            currentGuess = rand.Next(0,remaining.Count-1);
            currentGuess = remaining[currentGuess].id-1;
            //while(lista[currentGuess].used == false)currentGuess = rand.Next(0,40);
            currPosition = rand.Next(1,4);
            currJudName = lista[currentGuess].judet;
            lista[currentGuess].used = false;
            if(gameMode==true)
            GameObject.Find("btnOption"+currPosition.ToString()).transform.GetChild(0).GetComponent<TMP_Text>().text = lista[currentGuess].judet;
            else GameObject.Find("btnOption"+currPosition.ToString()).transform.GetChild(0).GetComponent<TMP_Text>().text = lista[currentGuess].resedinta;
            if(gameMode == false)
                if(PlayerPrefs.GetInt("language")%2 == 0)
                    GameObject.Find("lblQuestion").GetComponent<TMP_Text>().text = "Resedinta judetului " + currJudName + "?";
                else
                    GameObject.Find("lblQuestion").GetComponent<TMP_Text>().text = "County's resindence of " + currJudName + "?";
            if(gameMode == true)
                {
                    Debug.Log(currentGuess);
                    GameObject.Find("imgJudet").GetComponent<RawImage>().texture = imgJud[currentGuess];
                     if(PlayerPrefs.GetInt("language")%2 == 0)
                        GameObject.Find("lblQuestion").GetComponent<TMP_Text>().text = "Ce judet este: ";
                     else 
                        GameObject.Find("lblQuestion").GetComponent<TMP_Text>().text = "What county is: ";
                }
            int[] verif = new int[4]{-1,-1,-1,-1};
            for(int j = 1 ; j <= 4; j++)
            {
                if(j == currPosition)continue;
                
                pos = rand.Next(0,40);
                
                while(pos == currentGuess || pos == verif[0] || pos == verif[1] || pos == verif[2] || pos == verif[3])pos = rand.Next(0,40);
                verif[j-1] = pos ;
                if(gameMode == true)GameObject.Find("btnOption"+j.ToString()).transform.GetChild(0).GetComponent<TMP_Text>().text = lista[pos].judet;               
                else GameObject.Find("btnOption"+j.ToString()).transform.GetChild(0).GetComponent<TMP_Text>().text = lista[pos].resedinta;                         
                GameObject.Find("btnOption"+j.ToString()).GetComponent<Button>().colors = cb ;
            }        
    }

    // Start is called before the first frame update
    void Start()
    {
        Input.simulateMouseWithTouches = true ;
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0f)
        {
            btn1.GetComponent<Button>().enabled = false ;
            btn2.GetComponent<Button>().enabled = false ;
            btn3.GetComponent<Button>().enabled = false ;
            btn4.GetComponent<Button>().enabled = false ;
            time -= Time.deltaTime;
            
        }
        else
        {
            btn1.GetComponent<Button>().enabled = true ;
            btn2.GetComponent<Button>().enabled = true ;
            btn3.GetComponent<Button>().enabled = true ;
            btn4.GetComponent<Button>().enabled = true ;
        }
        

        if(currLevel<11)
        GameObject.Find("panelScore").transform.GetChild(0).GetComponent<TMP_Text>().text = currLevel.ToString() + "/10";
        //GameObject.Find("panelTimer").transform.GetChild(0).GetComponent<TMP_Text>().text = currScore.ToString() + "/10";
        if(PlayerPrefs.GetInt("language")%2 == 0)
        GameObject.Find("panelTimer").transform.GetChild(0).GetComponent<TMP_Text>().text = " Intrebarea: ";
        else 
         GameObject.Find("panelTimer").transform.GetChild(0).GetComponent<TMP_Text>().text = " Question: ";
    }
}
