using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class volumeIcon : MonoBehaviour
{

    [SerializeField] Texture volOn, volOff;
    public int volumee = 0 ;

    public void btnVolPress()
    {   volumee++;
        if(volumee %2 == 0)
            gameObject.GetComponentInChildren<RawImage>().texture = volOn;
        else    
            gameObject.GetComponentInChildren<RawImage>().texture = volOff;
         PlayerPrefs.SetInt("volume",volumee);
    }
    void Start()
    {
        if(!PlayerPrefs.HasKey("volume"))
            PlayerPrefs.SetInt("volume",0);
        else   
            volumee = PlayerPrefs.GetInt("volume");
            
        if(volumee %2 == 0)
            gameObject.GetComponentInChildren<RawImage>().texture = volOn;
        else    
            gameObject.GetComponentInChildren<RawImage>().texture = volOff;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
