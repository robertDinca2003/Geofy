using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElemPos3 : MonoBehaviour
{
    Resolution r;
    public float w,h;
    public float posX,posY;

    public bool whichL = false;
    public bool enable = false ;
    public void position(float val, bool which)
    {

         r= Screen.currentResolution;
        float z = r.width;
        if(z > r.height) z= r.height;
        if(whichL == true)
        {
                posY = val; posX = 0;
                this.transform.localPosition = new Vector3(0, z*(((val+90)*100/180f)*60f/100f-30f)/100f, 0);
                this.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(z*120f/100f,z/75f);
                Debug.Log(val.ToString() + " " + this.name);
        }
        if(whichL == false)
        {
                posX = val; posY = 0;
                this.transform.localPosition = new Vector3(z*(((val+180)*100/360f)*120f/100f-60f)/100f ,0, 0 );
                this.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(z/75f,z*60f/100f);
                Debug.Log(val.ToString() + " " + this.name);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enable)position(posX+posY,true);
    }
}
