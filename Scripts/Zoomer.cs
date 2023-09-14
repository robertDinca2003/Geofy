using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Zoomer : MonoBehaviour
{
    [SerializeField] private Transform map; 
    [SerializeField] private GameObject slider ;
    public void Zooming()
    {
        Vector3 newZoom = map.transform.localScale; 
        newZoom.x = 1 +  slider.transform.GetComponent<Slider>().value;
        newZoom.y = 1 + slider.transform.GetComponent<Slider>().value;
        map.transform.localScale  = newZoom ;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Zooming();   
    }
}
