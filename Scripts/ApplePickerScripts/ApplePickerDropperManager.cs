using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
662007329
Zhi Zheng
*/
public class ApplePickerDropperManager : MonoBehaviour
{
    public GameObject[] droppers;
    public GameObject[] dropperPrefab;
    private Coroutine extraDrops;
    private float t;


    void Start(){
        t = 0.0f;
        //to start off the dropping and then to start the coroutine
        StartDrop();
        while(extraDrops == null){
            extraDrops = StartCoroutine(Dropping());
        }
    }
    void StartDrop(){
        //for every dropper, there is an invoke repeating function to drop a mineral every 1.5 seconds and 5 seconds for vespene
        foreach(GameObject drop in droppers){
            drop.GetComponent<Rigidbody2D>().velocity = new Vector2(3.0f, 0.0f);
            if(drop.tag.Equals("MineralDrop")){
                InvokeRepeating("DropMineral", 1.5f, 1.5f);
            }
            if(drop.tag.Equals("MineralDrop2")){
                InvokeRepeating("DropMineral2", 1.5f, 1.5f);
            }
            if(drop.tag.Equals("VespeneDrop")){
                InvokeRepeating("DropVespene", 1.5f, 5.0f);
            }
            if(drop.tag.Equals("VespeneDrop2")){
                InvokeRepeating("DropVespene2", 1.5f, 5.0f);
            }
        }
    }
    void ExtraDrop(){
        foreach(GameObject drop in droppers){
            if(drop.tag.Equals("MineralDrop")){
                InvokeRepeating("DropMineral", t, 1.5f);
            }
            if(drop.tag.Equals("MineralDrop2")){
                InvokeRepeating("DropMineral2", t, 1.5f);
            }
            if(drop.tag.Equals("VespeneDrop")){
                InvokeRepeating("DropVespene", t, 5.0f);
            }
            if(drop.tag.Equals("VespeneDrop2")){
                InvokeRepeating("DropVespene2", t, 5.0f);
            }
        }
    }
    void DropMineral(){
        Instantiate(dropperPrefab[0], droppers[0].gameObject.transform.position, Quaternion.identity);
    }
    void DropMineral2(){
        Instantiate(dropperPrefab[0], droppers[2].gameObject.transform.position, Quaternion.identity);
    }
    void DropVespene(){
        Instantiate(dropperPrefab[1], droppers[1].gameObject.transform.position, Quaternion.identity);
    }
    void DropVespene2(){
        Instantiate(dropperPrefab[1], droppers[3].gameObject.transform.position, Quaternion.identity);
    }

    IEnumerator Dropping(){
        //for every 30 seconds there would be an increase of the increment of the area dropped, making the objects dropped more visible since it isnt on top of each other
        while(true){
            yield return new WaitForSeconds(30.0f);
            t++;
            ExtraDrop();
        }
    }

    // Update is called once per frame
    void Update(){
        ChangeLocation();
    }
    void ChangeLocation(){
        //for every dropper, their position will be tested: if the dropper reaches the boundary it will go back
        foreach(GameObject drop in droppers){
            if(drop.transform.position.x > 7.0f){
                drop.transform.position = new Vector2(6.99f, drop.transform.position.y);
                drop.GetComponent<Rigidbody2D>().velocity *= -1.0f;
            }
            if(drop.transform.position.x < -7.0f){
                drop.transform.position = new Vector2(-6.99f, drop.transform.position.y);
                drop.GetComponent<Rigidbody2D>().velocity *= -1.0f;
            }
        }
    }
}
