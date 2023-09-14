using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XpLevelUpdate : MonoBehaviour
{

    GameObject txtLevel;
    GameObject imgProgress;

    int nr = 0;
    public float width,x;
    public void updateLevel()
    {
        txtLevel = GameObject.Find("lblLevel");
        imgProgress = GameObject.Find("imgLevel");

        txtLevel.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("level").ToString();
        imgProgress.GetComponent<ElemPosition>().w  = width * (100 * PlayerPrefs.GetInt("xp") / PlayerPrefs.GetInt("level")/150) / 100;
        imgProgress.GetComponent<ElemPosition>().posX = x - width/2 + imgProgress.GetComponent<ElemPosition>().w / 2f;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nr == 0)
        {
            updateLevel();
            nr++;
        }
        //txtLevel.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("level").ToString();
        //imgProgress.GetComponent<ElemPosition>().w  = width * (100 * PlayerPrefs.GetInt("xp") / PlayerPrefs.GetInt("level")/150) / 100;
        
    }
}
