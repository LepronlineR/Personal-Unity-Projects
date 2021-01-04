using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
662007329
Zhi Zheng
*/

public class ApplePickerPlayerScript : MonoBehaviour
{
    public int mineralCount;
    public int vespeneCount;
    public GameObject AudioManager;
    void Start(){
        mineralCount = 0;
        vespeneCount = 0;
    }

    // Update is called once per frame
    void Update(){
        MouseControls();
        PlayerPrefs.SetInt("player mineral",mineralCount);
        PlayerPrefs.SetInt("player vespene",vespeneCount);
    }
    void MouseControls(){
        Vector3 tempPos;

        tempPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tempPos.z = transform.position.z;
        tempPos.y = transform.position.y;

        transform.position = tempPos;
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag.Equals("Mineral")){
            if(SoundRandomizer())
                AudioManager.GetComponent<ApplePickerAudioManagerScript>().PlayRandomClipProbe();
            mineralCount+=5;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag.Equals("Vespene")){
            if(SoundRandomizer())
                AudioManager.GetComponent<ApplePickerAudioManagerScript>().PlayRandomClipProbe();
            vespeneCount+=5;
            Destroy(collision.gameObject);
        }
    }
    bool SoundRandomizer(){
        int getNum = 1;
        int randomNum = Random.Range(0,10);
        if(getNum==randomNum)
            return true;
        return false;
    }
}
