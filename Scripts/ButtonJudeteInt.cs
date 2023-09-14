using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonJudeteInt : MonoBehaviour
{
    GameObject game ;
    public GameObject button; 
    GameObject anim;
    GameObject[] jud = new GameObject[0];
    public GameObject temp ;
    public int score;
    public void logicBtn()
    {    
        
        game = GameObject.Find("Game4");
        anim = GameObject.Find("imgWrong");
        Debug.Log("working");
        //cb.normalColor = Color.green;
        if(button.name== game.GetComponent<GuessJudeteLogic>().currJudName)
        {
            game.GetComponent<GuessJudeteLogic>().currScore += PlayerPrefs.GetInt("score");
            if(jud.Length == 0)
            jud = GameObject.FindGameObjectsWithTag("btns");
            temp = jud[0];
            foreach(GameObject obj in jud)if(obj.name == game.GetComponent<GuessJudeteLogic>().currJudName)temp = obj;  
            if(PlayerPrefs.GetInt("score") == 3)  
            temp.GetComponent<RawImage>().color = Color.green;
            if(PlayerPrefs.GetInt("score") == 2)  
            temp.GetComponent<RawImage>().color = Color.yellow;
            if(PlayerPrefs.GetInt("score") == 1)  
            {
                Color orange; 
                ColorUtility.TryParseHtmlString("#FFA500", out orange);
                temp.GetComponent<RawImage>().color = orange;
            }
            game.GetComponent<GuessJudeteLogic>().currLevel++;

            button.GetComponent<Button>().enabled = false ;
            
            anim.GetComponent<ElemPos2>().posX =0;
            anim.GetComponent<ElemPos2>().posY =0;

            PlayerPrefs.SetInt("score",3);
            game.GetComponent<GuessJudeteLogic>().JudeteLogic();
            
            
            return;
        }
        else
        {
            //cb.normalColor = Color.red;
           PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")-1);
           anim.GetComponent<ElemPos2>().posX = this.GetComponent<ElemPos2>().posX;
           anim.GetComponent<ElemPos2>().posY = this.GetComponent<ElemPos2>().posY;
           anim.GetComponent<Animator>().Play("New Animation");
           game.GetComponent<GuessJudeteLogic>().time = 1f;
         
          
        }

        if(PlayerPrefs.GetInt("score") == 0)
        {
             if(jud.Length == 0)
             jud = GameObject.FindGameObjectsWithTag("btns");
            temp = jud[0];
            foreach(GameObject obj in jud)if(obj.name == game.GetComponent<GuessJudeteLogic>().currJudName)temp = obj;  
            temp.GetComponent<RawImage>().color = Color.red;
             game.GetComponent<GuessJudeteLogic>().currLevel++;
             PlayerPrefs.SetInt("score",3);
             game.GetComponent<GuessJudeteLogic>().JudeteLogic();
             
             
            return;
        }
         //Debug.Log(game.GetComponent<GuessJudeteLogic>().currJudName + " " +PlayerPrefs.GetInt("score"));
        
    }

    public void newGuess(){
        score = 3;
    }

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
