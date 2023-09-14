using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine.EventSystems;
public class ListDisplay : MonoBehaviour
{
     int nr = 0;

     string elem;
     string[] country = new string[169];
    Font font;
    Resolution r;

    public TextAsset bd;
    GuessCountryLogic guessLog ;
    scoreUpdate scr ;
    string currectGuess = "Romania";


    public void ResetPop()
    {
        //scr = GameObject.Find("lblGuesses").GetComponent<scoreUpdate>();
        scr.ResetScore();
        for(int i = gameObject.transform.childCount-1 ; i >= 0 ; i--)
        {
           Transform temp = gameObject.transform.GetChild(i);
            temp.GetComponent<Button>().enabled = true ;
            temp.GetComponent<Image>().color = Color.white;
        }
    }
    public void Populate()
    {
           guessLog = GameObject.Find("Game1").GetComponent<GuessCountryLogic>();
           guessLog.GenerateGame();
           guessLog.resetObj();
           currectGuess = guessLog.guessCountry; 
           Debug.Log(currectGuess + " -<");
           if(nr != 0)return;
            
            scr = GameObject.Find("lblGuesses").GetComponent<scoreUpdate>();
            
            
            
            country = bd.text.Split(new string[] {"\n"}, System.StringSplitOptions.None);

           r=  Screen.currentResolution;
            foreach(string name in country)
            {
                if(name.Length == 0)break;
                elem = "";
                int i = 0; while(name[i] != ',')i++; i++;
                while(name[i] != ',')if(name[i] != '@'){elem = elem + name[i];i++;} else {elem = elem + ' ';i++;}
                i++;
                GameObject newCountry = new GameObject(elem);
                newCountry.AddComponent<Button>();
                newCountry.AddComponent<Image>();


                GameObject childCountry = new GameObject("txt");
                childCountry.AddComponent<Text>();
                childCountry.GetComponent<Text>().text = elem ;
                childCountry.GetComponent<Text>().alignment =UnityEngine.TextAnchor.MiddleCenter;
                childCountry.GetComponent<Text>().font = GameObject.Find("Font").GetComponent<Text>().font;
                childCountry.GetComponent<Text>().color = Color.black;
                childCountry.GetComponent<Text>().resizeTextForBestFit = true;
               
                childCountry.transform.SetParent(newCountry.transform);
                newCountry.transform.SetParent(this.transform);
                
                newCountry.GetComponent<Button>().enabled = true ;
                newCountry.GetComponent<Button>().targetGraphic = newCountry.GetComponent<Image>();
                newCountry.GetComponent<Button>().colors =GameObject.Find("Font").GetComponent<Button>().colors;
                newCountry.GetComponent<RectTransform>().localScale = new Vector3(1,1,0);
                newCountry.GetComponent<RectTransform>().sizeDelta = new Vector2(newCountry.GetComponent<RectTransform>().sizeDelta.y,r.height/20f );
                childCountry.GetComponent<RectTransform>().sizeDelta=  new Vector2(r.width*0.15f-10f,r.height/20f);

                float lat= 0 , longi = 0;
                elem = "";
                while(name[i] != ',')if(name[i] != '.'){elem = elem + name[i];i++;} else {elem = elem + ',';i++;}
                lat = float.Parse(elem);
                i++;
                elem = "";
                while(name[i] != ',')if(name[i] != '.'){elem = elem + name[i];i++;} else {elem = elem + ',';i++;}
                longi = float.Parse(elem);

                
                
                newCountry.GetComponent<Button>().onClick.AddListener(()=>{
                    if(scr.currScore >= 10 || guessLog.isWon == 1)return;
                    GameObject btn = newCountry;
                    if(currectGuess == btn.name)
                    {
                       btn.GetComponent<Image>().color = Color.green;
                       guessLog.WinGame();
                    }
                    else
                    {
                         btn.GetComponent<Image>().color = Color.red;
                    }
                    GameObject.Find("CoordLines").transform.GetChild(0).GetComponent<ElemPos3>().position(lat,true);
                    GameObject.Find("CoordLines").transform.GetChild(1).GetComponent<ElemPos3>().position(longi,true);
                    btn.GetComponent<Button>().enabled = false ;
                    scr.IncrementScore();
                    guessLog.verifChoice(btn.name);
                });


                
                
                
                nr++;
            }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
