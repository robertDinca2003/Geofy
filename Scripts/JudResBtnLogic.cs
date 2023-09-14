using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JudResBtnLogic : MonoBehaviour
{

    GameObject game ;

    public bool gameMode;
    public GameObject button; 

    

    public void logicBtn()
    {
        if(gameMode == false)
            game = GameObject.Find("Game2");
        if(gameMode == true)
            game = GameObject.Find("Game3");
        ColorBlock cb  = this.GetComponent<Button>().colors;
        //cb.normalColor = Color.green;
        if(gameMode == true)
        {
            if(button.transform.GetChild(0).GetComponent<TMP_Text>().text == game.GetComponent<ResedinteGameLogic>().currJudName)
            {
            this.transform.GetComponent<Button>().colors = cb;
            game.GetComponent<ResedinteGameLogic>().currScore++;
            }
            else
            {
            //cb.normalColor = Color.red;
            this.transform.GetComponent<Button>().colors = cb;
            }
        }
        
        else {if(button.transform.GetChild(0).GetComponent<TMP_Text>().text == game.GetComponent<ResedinteGameLogic>().lista[game.GetComponent<ResedinteGameLogic>().currentGuess].resedinta)
        {
            this.transform.GetComponent<Button>().colors = cb;
            game.GetComponent<ResedinteGameLogic>().currScore++;
        }
        else
        {
            this.transform.GetComponent<Button>().colors = cb;
        }}
        game.GetComponent<ResedinteGameLogic>().currLevel++;
        game.GetComponent<ResedinteGameLogic>().time = 1f;
        game.GetComponent<ResedinteGameLogic>().ResJudGameLogic();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
