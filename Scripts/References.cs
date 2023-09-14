using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class References : MonoBehaviour
{
    public GameObject scrollbar,mask,butBack;

    AdsInitializer ads;
    // Start is called before the first frame update

    public void launchAds()
    {
        if(PlayerPrefs.GetInt("counter")%2 == 1)ads.LoadInterstatialAd();
        Debug.Log(PlayerPrefs.GetInt("counter"));
    }
    void Start()
    {
        ads = this.GetComponent<AdsInitializer>();
        if(!PlayerPrefs.HasKey("xp")) PlayerPrefs.SetInt("xp",0);
        Debug.Log(PlayerPrefs.GetInt("xp"));
        if(!PlayerPrefs.HasKey("level"))PlayerPrefs.SetInt("level",1);
        Debug.Log(PlayerPrefs.GetInt("level"));
        if(!PlayerPrefs.HasKey("counter"))PlayerPrefs.SetInt("counter",0);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("xp") >= PlayerPrefs.GetInt("level") * 120)
        {
            PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") - PlayerPrefs.GetInt("level") * 120);
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level")+1);
            Debug.Log(PlayerPrefs.GetInt("level").ToString() + " " + PlayerPrefs.GetInt("xp"));
        }
    }
}
