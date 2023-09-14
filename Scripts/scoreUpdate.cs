using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scoreUpdate : MonoBehaviour
{
    public int currScore = 0 ;
    int lang;
    int nr;
    string guess ;

    TMP_Text txt ;

    public void ResetScore(){currScore = 0 ;nr = 0;}
    public void IncrementScore()
    {currScore++;}

    public void Start()
    {
        currScore = 0 ;
        nr = 0;
        lang = PlayerPrefs.GetInt("language");
        if(lang % 2 == 0)guess = "Incercare ";
        else guess = "Guess ";
        txt = this.transform.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = guess + currScore.ToString() + "/10";
        if(nr != 0) return;
        if(currScore == 10)if(GameObject.Find("Game1").GetComponent<GuessCountryLogic>().isWon == 0){nr++;GameObject.Find("Game1").GetComponent<GuessCountryLogic>().LoseGame();}
    }
}
