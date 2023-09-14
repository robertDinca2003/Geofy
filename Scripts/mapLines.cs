using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapLines : MonoBehaviour
{
    public float latitude, longitude;

    GameObject line, column; 
    GuessCountryLogic guessLog; 

    Resolution r; 

    public float z ;
    public int nr = 0 ;
    public void updateLines()
    {
        if(nr < 1)Start();
        latitude = guessLog.getLatitude();
        Debug.Log(latitude);
        longitude = guessLog.getLongitude() ;
        Debug.Log(longitude);

        latitude = latitude * z * 0.6f / 180f - z/10;
        longitude = -0.3f * z + (longitude+53) * 0.3f * z / 135f ;
        
        line.GetComponent<RectTransform>().localPosition = new Vector3(latitude,0,0);
        column.GetComponent<RectTransform>().localPosition = new Vector3(0,longitude,0);

        line.GetComponent<RectTransform>().sizeDelta = new Vector2(z/100,2000);
        column.GetComponent<RectTransform>().sizeDelta = new Vector2(2000,z/100);
        
    }

    void Start()
    {
        r = Screen.currentResolution ;
        z = r.width; 
        if(z > r.height) z = r.height ;

        guessLog = this.GetComponent<GuessCountryLogic>();
        line = new GameObject("Line");
        column = new GameObject("Column");
        
        

        line.transform.SetParent(GameObject.Find("CoordLines").transform);
        column.transform.SetParent(GameObject.Find("CoordLines").transform);

        line.AddComponent<Image>();
        column.AddComponent<Image>();

        line.GetComponent<Image>().color = Color.red ;
        column.GetComponent<Image>().color = Color.red ;

        line.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        column.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);

/*
        line.AddComponent<ElemPosition>();
        column.AddComponent<ElemPosition>();

        line.GetComponent<ElemPosition>().square = true ;
        line.GetComponent<ElemPosition>().h = 0.005f;
        line.GetComponent<ElemPosition>().w = 100f;
        line.GetComponent<ElemPosition>().posX = 50f;
        line.GetComponent<ElemPosition>().posY = 50f;

        column.GetComponent<ElemPosition>().square = true ;
        column.GetComponent<ElemPosition>().h = 100f;
        column.GetComponent<ElemPosition>().w = 0.005f;
        column.GetComponent<ElemPosition>().posX = 50f;
        column.GetComponent<ElemPosition>().posY = 50f;
*/
        

        nr++;
    }   

    // Update is called once per frame
    void Update()
    {
    //SupdateLines();
    }
}
