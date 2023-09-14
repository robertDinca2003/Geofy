using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Language : MonoBehaviour
{
    public int lang = 0; 

    public void btnLangPress(){lang++;PlayerPrefs.SetInt("language",lang);}
    void Start()
    {
        if(!PlayerPrefs.HasKey("language"))
            PlayerPrefs.SetInt("language",1);
        else    
            lang = PlayerPrefs.GetInt("language");
    }

    // Update is called once per frame
    void Update()
    {
        if(lang%2 == 0)gameObject.GetComponentInChildren<TMP_Text>().text = "RO";
        else gameObject.GetComponentInChildren<TMP_Text>().text = "EN";
    }
}
