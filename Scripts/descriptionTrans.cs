using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class descriptionTrans : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("language") % 2 == 0)
            this.GetComponent<TMP_Text>().text = "Descoperă cât de multe știi atât despre țara nostră, cât și despre întreaga lume."+"\n"+
"Ai ales aplicația potrivită!"+"\n"+
"Jocuri interactive prin care înveți diferite aspecte ale lumii."+"\n"+
"Harți interactive și diferite moduri de joc."+"\n"+
"Completeaza quiz-uri!"+"\n"+
"Scopul proiectului este educațional."+"\n"+
"Dezvoltă cultura generală.";
        else
            this.GetComponent<TMP_Text>().text = 
"Are you ready to put your geography skills to the ultimate test?"+"\n"+
"Introducing Geofy, the new and exciting game that challenges you to guess the countries and counties of various locations around the world."+"\n"+
"Explore the maps and try to pinpoint the exact spot."+"\n"+
"With each correct guess, you'll earn points and gain a higher level. But be careful - one wrong answer can set you back."+"\n"+
"In the Guess the country mode, you'll be given a single map and must use your knowledge of geography to determine the correct location."+"\n"+
"Explore the map and try to pinpoint the exact spot."+"\n"+
"Try to complete the maps to perfection. Make it all green!"+"\n"+
"Do you have what it takes to become the ultimate geo-guru in Geofy?"+"\n"+"\n"+"\n"+"\n" + ".";
    }
}
