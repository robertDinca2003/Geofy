using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Translate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string romana;
    [SerializeField] string engleza;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerPrefs.GetInt("language")%2 == 0)
            this.GetComponent<TMP_Text>().text = romana;
        else    
            this.GetComponent<TMP_Text>().text = engleza;    
    }
}
