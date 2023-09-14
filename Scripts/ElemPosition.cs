using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElemPosition : MonoBehaviour
{
    public float posX;
    public float posY;
    public bool enable = true ;
    public float w;
    public float h;

    public bool square = false ;
    public void Start()
    {
        Resolution r = Screen.currentResolution;
        //Debug.Log(r.width + "x" + r.height + " : " + r.refreshRate);

        

        RectTransform tr = gameObject.GetComponent<RectTransform>();
         
       

        if(gameObject.name == "iconVolume" || gameObject.name == "imgMap" || square || gameObject.name == "Triangle")
        {
            float z = r.width ;
            if(z > r.height) z = r.height ; 
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(w*z/100,h*z/100); 
        }
        else
        {
             tr.localPosition = new Vector3(posX * r.width / 100 - r.width/2 ,posY * r.height / 100 - r.height/2,0);
         
            tr.sizeDelta = new Vector2(w*r.width/100, h*r.height/100);
        }
        if(square)
        {
             tr.localPosition = new Vector3(posX * r.width / 100 - r.width/2 ,posY * r.height / 100 - r.height/2,0);
         
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enable)
            Start();
    }
}
