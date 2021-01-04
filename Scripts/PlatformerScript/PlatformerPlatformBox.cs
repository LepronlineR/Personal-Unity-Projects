using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlatformBox : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] bool b;
    private SpriteRenderer sr;

    void Start(){
        sr = GetComponent<SpriteRenderer>();
        platform.SetActive(false);
    }

    private void OnTriggerEnter2D(){
        if(b){
            sr.color = Color.red;
            platform.SetActive(false);
        }else{
            sr.color = Color.green;
            platform.SetActive(true);
        }
    }
    private void OnTriggerExit2D(){
        sr.color = Color.white;
        if(b)
            platform.SetActive(true);
        else
            platform.SetActive(false);
    }
}
