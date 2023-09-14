using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class btnUpdate : MonoBehaviour
{

    public bool pressed = false ;
    [SerializeField]  Sprite skinUnpress; 
    [SerializeField]  Sprite skinPress;

    [SerializeField]  GameObject txtMesh; 

    [SerializeField] string wordRo, wordEn;
    Image _img;
    RectTransform tr;

    [SerializeField]float sizeX,sizeY,sizeY2;
    public void btnPress(bool p)
    {
        pressed = p;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _img = gameObject.GetComponent<Image>();
        tr = txtMesh.GetComponent<RectTransform>();
        sizeX = tr.sizeDelta.x;
        sizeY = tr.sizeDelta.y * 0.8f;
        sizeY2 = tr.sizeDelta.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if(wordRo.Length != 0 )
        if(PlayerPrefs.GetInt("language") %2 == 0)
            txtMesh.GetComponent<TMP_Text>().text = wordRo;
        else
            txtMesh.GetComponent<TMP_Text>().text = wordEn;

        if(pressed == true)
        {
            _img.sprite = skinPress;
            //txtMesh.GetComponent<TMP_Text>().alignment = TMPro.TextAlignmentOptions.Bottom;
            
            tr.localPosition = new Vector3(tr.localPosition.x,-5);
            tr.sizeDelta = new Vector2(tr.sizeDelta.x,sizeY2);
        }
        else
        {
            _img.sprite = skinUnpress;
            //txtMesh.GetComponent<TMP_Text>().alignment = TMPro.TextAlignmentOptions.Top;
            tr.localPosition = new Vector3(tr.localPosition.x,10);
            tr.sizeDelta = new Vector2(sizeX, sizeY);
        }


    }
}
