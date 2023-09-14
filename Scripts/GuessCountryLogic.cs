using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
using UnityEngine.UI;
using TMPro;
public class GuessCountryLogic : MonoBehaviour
{
    public GameObject winning;
    mapLines linesCoord;
    public TextAsset bd;
    public int isWon = 0 ;
    public int isRunning = 0;

    public int idCurrentGuess = -1; 
    string[] listCountry = new string[169];
    public struct countries{
       public int ID;
       public string Name;
       public int Population;

       public string Continent;
       public float Longitude;
       public float Latitude;
    };
        
    public countries[] country = new countries[169];

    public countries temp;
    public string guessCountry = "Romania";

    GameObject gamePopulation;
    GameObject gameLongitude;
    GameObject gameLatitude;
    GameObject gameContinent;

    int nrTemp;
    public void LoseGame()
    {
        isRunning = 0 ;
        GameObject.Find("lblAnswer").GetComponent<TMP_Text>().text = guessCountry;
        winning.SetActive(true);
        GameObject.Find("btnBack").GetComponent<Button>().enabled = false;
        if(PlayerPrefs.GetInt("language") % 2 == 1)
        winning.transform.GetChild(2).GetComponent<TMP_Text>().text = "Try another round!";
        if(PlayerPrefs.GetInt("language") % 2 == 0)
         winning.transform.GetChild(2).GetComponent<TMP_Text>().text = "Incearca inca o runda!";
        PlayerPrefs.SetInt("counter", PlayerPrefs.GetInt("counter")+1);
        if(nrTemp ==0)
        {GameObject.Find("Font").GetComponent<References>().launchAds();nrTemp++;}
         GameObject.Find("lblXp").GetComponent<TMP_Text>().text = "+0"+ " XP";
    }
    public void WinGame()
    {
        isWon = 1 ;
        isRunning = 0 ;
        PlayerPrefs.SetInt("xp",PlayerPrefs.GetInt("xp") + (10-GameObject.Find("lblGuesses").GetComponent<scoreUpdate>().currScore-1)*40);
        GameObject.Find("lblAnswer").GetComponent<TMP_Text>().text = guessCountry;
        winning.SetActive(true);
        GameObject.Find("btnBack").GetComponent<Button>().enabled = false;
        winning.transform.GetChild(2).GetComponent<TMP_Text>().text = "Score " + (GameObject.Find("lblGuesses").GetComponent<scoreUpdate>().currScore+1).ToString() + "/10";
        PlayerPrefs.SetInt("counter", PlayerPrefs.GetInt("counter")+1);
        if(nrTemp ==0)
        {GameObject.Find("Font").GetComponent<References>().launchAds();nrTemp++;}
        GameObject.Find("lblXp").GetComponent<TMP_Text>().text = "+"+ ((10-GameObject.Find("lblGuesses").GetComponent<scoreUpdate>().currScore-1)*40).ToString() + " XP";
    }

    public float getLatitude()
    {
        if(idCurrentGuess == -1)return -1;
        return temp.Latitude;
    }
    public float getLongitude()
    {
        if(idCurrentGuess == -1)return -1;
        return temp.Longitude;
    }

    public float absolute(float nr){if(nr < 0) nr*= -1; return nr;}
    public void resetObj()
    {
        gamePopulation = GameObject.Find("Population");
        gameContinent = GameObject.Find("Continent");
        gameLatitude = GameObject.Find("Latitude");
        gameLongitude = GameObject.Find("Longitude");

        GameObject.Find("lblNrPop").GetComponent<TMP_Text>().text = "";
        GameObject.Find("lblNrCont").GetComponent<TMP_Text>().text = "";
        GameObject.Find("lblNrLatid").GetComponent<TMP_Text>().text = "";
        GameObject.Find("lblNrLongit").GetComponent<TMP_Text>().text = "";


        gameContinent.transform.GetChild(0).GetComponent<RawImage>().color = Color.gray;
        //gameContinent.transform.GetChild(1).GetComponent<RectTransform>().localRotation = UnityEngine.Quaternion.Euler(0,0,0);
        gamePopulation.transform.GetChild(0).GetComponent<RawImage>().color = Color.gray;
        gamePopulation.transform.GetChild(1).GetComponent<RectTransform>().localRotation = UnityEngine.Quaternion.Euler(0,0,0);
        gameLatitude.transform.GetChild(0).GetComponent<RawImage>().color = Color.gray;
        gameLatitude.transform.GetChild(1).GetComponent<RectTransform>().localRotation = UnityEngine.Quaternion.Euler(0,0,0);
        gameLongitude.transform.GetChild(0).GetComponent<RawImage>().color = Color.gray;
        gameLongitude.transform.GetChild(1).GetComponent<RectTransform>().localRotation = UnityEngine.Quaternion.Euler(0,0,0);
    
        gamePopulation.transform.GetChild(1).gameObject.SetActive(true);
        gameLatitude.transform.GetChild(1).gameObject.SetActive(true);
        gameLongitude.transform.GetChild(1).gameObject.SetActive(true);

        GameObject.Find("lblAnswer").GetComponent<TMP_Text>().text = "";
        winning.SetActive(false);
    }

    public void testDebug()
    {
        foreach(countries i in country)Debug.Log(i.ID.ToString() + " "+ i.Name+ " " + i.Latitude + " "+i.Longitude + " " + i.Continent + " " + i.Population);
    }
    

    public void verifChoice(string selection)
    {
         temp = country[0];
        foreach(countries i in country)if(i.Name == selection)temp = i; 

        gamePopulation = GameObject.Find("Population");
        gameContinent = GameObject.Find("Continent");
        gameLatitude = GameObject.Find("Latitude");
        gameLongitude = GameObject.Find("Longitude");

        GameObject.Find("lblNrPop").GetComponent<TMP_Text>().text = temp.Population.ToString();
        GameObject.Find("lblNrCont").GetComponent<TMP_Text>().text = temp.Continent.ToString();
        GameObject.Find("lblNrLatid").GetComponent<TMP_Text>().text = temp.Latitude.ToString();
        GameObject.Find("lblNrLongit").GetComponent<TMP_Text>().text = temp.Longitude.ToString();
        //linesCoord = this.GetComponent<mapLines>();
        //linesCoord.updateLines();

        Color orange; 
        ColorUtility.TryParseHtmlString("#FFA500", out orange);

        //Debug.Log(selection)    ;    Debug.Log(temp.Latitude); Debug.Log(country[idCurrentGuess].Latitude + " -");

        if(temp.Continent == country[idCurrentGuess].Continent)
        {
                gameContinent.transform.GetChild(0).GetComponent<RawImage>().color = Color.green;
        }
        else
        {
                gameContinent.transform.GetChild(0).GetComponent<RawImage>().color = Color.red;
        }

        if(temp.Population == country[idCurrentGuess].Population)
        {
            gamePopulation.transform.GetChild(0).GetComponent<RawImage>().color = Color.green;
            RawImage image = gamePopulation.transform.GetChild(1).GetComponent<RawImage>();
            gamePopulation.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (temp.Population < country[idCurrentGuess].Population) 
        {
            gamePopulation.transform.GetChild(1).gameObject.SetActive(true);
            gamePopulation.transform.GetChild(1).GetComponent<RectTransform>().localRotation = Quaternion.Euler(0,0,0);
        }
        else if(temp.Population > country[idCurrentGuess].Population)
        {
            gamePopulation.transform.GetChild(1).gameObject.SetActive(true);
            gamePopulation.transform.GetChild(1).GetComponent<RectTransform>().localRotation = Quaternion.Euler(0,0,180);
        
        }
        if(temp.Population == country[idCurrentGuess].Population)
        {
            gamePopulation.transform.GetChild(0).GetComponent<RawImage>().color = Color.green;
            RawImage image = gamePopulation.transform.GetChild(1).GetComponent<RawImage>();
            gamePopulation.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if(absolute(temp.Population - country[idCurrentGuess].Population) <= 50000)
            gamePopulation.transform.GetChild(0).GetComponent<RawImage>().color = Color.yellow;
        else if(absolute(temp.Population - country[idCurrentGuess].Population) <= 1000000)
            gamePopulation.transform.GetChild(0).GetComponent<RawImage>().color = orange;
        else
        {
            gamePopulation.transform.GetChild(0).GetComponent<RawImage>().color = Color.red;
        }


        if(temp.Latitude == country[idCurrentGuess].Latitude)
        {
            gameLatitude.transform.GetChild(0).GetComponent<RawImage>().color = Color.green;
            RawImage image = gameLatitude.transform.GetChild(1).GetComponent<RawImage>();
            gameLatitude.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (temp.Latitude < country[idCurrentGuess].Latitude) 
        {
            gameLatitude.transform.GetChild(1).gameObject.SetActive(true);
            gameLatitude.transform.GetChild(1).GetComponent<RectTransform>().localRotation = Quaternion.Euler(0,0,270);
        }
        else if(temp.Latitude > country[idCurrentGuess].Latitude)
        {
            gameLatitude.transform.GetChild(1).gameObject.SetActive(true);
            gameLatitude.transform.GetChild(1).GetComponent<RectTransform>().localRotation = Quaternion.Euler(0,0,90);
        
        }
        
        if(temp.Latitude == country[idCurrentGuess].Latitude)
        {
            gameLatitude.transform.GetChild(0).GetComponent<RawImage>().color = Color.green;
            RawImage image = gameLatitude.transform.GetChild(1).GetComponent<RawImage>();
            gameLatitude.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if(absolute(temp.Latitude - country[idCurrentGuess].Latitude) <= 10)
            gameLatitude.transform.GetChild(0).GetComponent<RawImage>().color = Color.yellow;
        else if(absolute(temp.Latitude - country[idCurrentGuess].Latitude) <= 30)
            gameLatitude.transform.GetChild(0).GetComponent<RawImage>().color = orange;
        else
        {
            gameLatitude.transform.GetChild(0).GetComponent<RawImage>().color = Color.red;
        }



        if(temp.Longitude == country[idCurrentGuess].Longitude)
        {
            gameLongitude.transform.GetChild(0).GetComponent<RawImage>().color = Color.green;
            RawImage image = gameLatitude.transform.GetChild(1).GetComponent<RawImage>();
            gameLongitude.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (temp.Longitude < country[idCurrentGuess].Longitude) 
        {
            gameLongitude.transform.GetChild(1).gameObject.SetActive(true);
            gameLongitude.transform.GetChild(1).GetComponent<RectTransform>().localRotation = Quaternion.Euler(0,0,0);
        }
        else if(temp.Longitude > country[idCurrentGuess].Longitude)
        {
            gameLongitude.transform.GetChild(1).gameObject.SetActive(true);
            gameLongitude.transform.GetChild(1).GetComponent<RectTransform>().localRotation = Quaternion.Euler(0,0,180);
        
        }

        if(temp.Longitude == country[idCurrentGuess].Longitude)
        {
            gameLongitude.transform.GetChild(0).GetComponent<RawImage>().color = Color.green;
            RawImage image = gameLatitude.transform.GetChild(1).GetComponent<RawImage>();
            gameLongitude.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if(absolute(temp.Longitude - country[idCurrentGuess].Longitude) <= 10)
            gameLongitude.transform.GetChild(0).GetComponent<RawImage>().color = Color.yellow;
        else if(absolute(temp.Longitude - country[idCurrentGuess].Longitude) <= 30)
            gameLongitude.transform.GetChild(0).GetComponent<RawImage>().color = orange;
        else
        {
            gameLongitude.transform.GetChild(0).GetComponent<RawImage>().color = Color.red;
        }


    }

    public void GenerateGame()
    {
        isWon = 0 ;
        isRunning = 1 ;
        nrTemp = 0;
        winning.SetActive(false);
        GameObject.Find("ScrollGameZoom").GetComponent<Slider>().value = 0;
        GameObject.Find("imgMap").GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
        GameObject.Find("btnBack").GetComponent<Button>().enabled = true;
        if(country[10].ID != 10)
        {
             //string readFromeFilePath = Application.streamingAssetsPath + "/BD/BazaFinal.txt";
             //listCountry = File.ReadAllLines(readFromeFilePath).ToList();
             listCountry = bd.text.Split(new string[] {"\n"}, System.StringSplitOptions.None);
                int nr = 0;
            
             foreach(string elem in listCountry)
             {
                Debug.Log(elem);
                if(nr>=169)break;
                string temp = "";
                int i = 0; 
                    while(elem[i]!=','){temp += elem[i];i++;}
                    country[nr].ID =  Int32.Parse(temp);
                    i++;
                    temp = "";
                    
                while(elem[i] != ','){temp += elem[i];i++;}
                    country[nr].Name = temp ;
                    i++;
                    temp = "";
                    
                while(elem[i] != ','){if(elem[i] != '.')temp += elem[i]; else temp += ',';i++;}
                    country[nr].Longitude = float.Parse(temp) ;
                    i++;
                temp = "";
                while(elem[i] != ','){if(elem[i] != '.')temp += elem[i]; else temp += ',';i++;}
                    country[nr].Latitude = float.Parse(temp) ;
                    i++;
                temp = "";
                while(elem[i] != ','){temp += elem[i];i++;}
                    country[nr].Continent = temp ;
                     
                    i++;
                temp = "";
                while(elem[i] != ','){temp += elem[i];i++;}
                    country[nr].Population = Int32.Parse(temp);
                nr++;
                //testDebug();
             }

        }

        System.Random rand = new System.Random();
        idCurrentGuess = rand.Next(1,169);
        guessCountry = country[idCurrentGuess].Name;
        Debug.Log(guessCountry + "  <-");

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
