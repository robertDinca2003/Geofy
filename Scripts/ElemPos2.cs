using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElemPos2 : MonoBehaviour
{
    Resolution r;
    public float w,h;
    public float posX,posY;

    public bool working = true;
    public void position()
    {
        r= Screen.currentResolution;
        float z = r.width;
        if(z > r.height) z= r.height;
        this.transform.localPosition = new Vector3(z * (posX*108.8f/100f-54.4f)/100f, z*(posY*77.76f/100f-38.88f)/100, 0);
        this.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(z*w/100,z*h/100);
        

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(working)
        position();
    }
}
