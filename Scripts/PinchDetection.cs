using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{

    [SerializeField]private float speed = 5f;
    private TouchControls controls;
    private Coroutine zoomCoroutine;

    [SerializeField]private Transform mapTransform;

    private void Awake()
    {
        controls = new TouchControls();

    }

    private  void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();   
    }
    // Start is called before the first frame update
    private void Start()
    {
     controls.Touch.SecondaryTouchContact.started += _ => ZoomStart();  
     controls.Touch.SecondaryTouchContact.canceled += _ => ZoomEnd();   
    }

    private void ZoomStart()
    {
      zoomCoroutine =  StartCoroutine(ZoomDetection());
    }


    private void ZoomEnd()
    {
        StopCoroutine(ZoomDetection());
    }

    IEnumerator ZoomDetection(){

        float previosDistance = 0f ,distance =0f;
        while(true){
            distance = Vector2.Distance(controls.Touch.Primaryfingerposition.ReadValue<Vector2>(), 
            controls.Touch.Secondaryfingerposition.ReadValue<Vector2>());

            
            if(distance > previosDistance)
            {
                    Vector3 targetScale = mapTransform.localScale;
                    if(targetScale.x > 1f)
                    {
                        targetScale.x-=0.1f;
                        targetScale.y-=0.1f;
                        mapTransform.localScale = Vector3.Slerp(mapTransform.localScale,targetScale, Time.deltaTime * speed);
            
                    }
              }
            else if(distance < previosDistance)
            {
                    Vector3 targetScale = mapTransform.localScale;
                    if(targetScale.x < 2f)
                    {
                        targetScale.x+=0.1f;
                        targetScale.y+=0.1f;
                        mapTransform.localScale = Vector3.Slerp(mapTransform.localScale,targetScale, Time.deltaTime * speed);
                    }
                    
            }
            previosDistance = distance;
            yield return null;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
