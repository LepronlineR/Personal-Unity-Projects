using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
662007329
Zhi Zheng
*/

public class ApplePickerBaseOperationsScript : MonoBehaviour
{
    public GameObject[] Players;
    public GameObject[] Bases;
    public GameObject[] Units;
    public AudioSource audioSource;
    public GameObject AudioManager;
    public AudioClip errorSound;
    public bool playerWin;
    public bool enemyWin;

    void Start(){
        playerWin = false;
        enemyWin = false;
    }

    public void BuyUnit(string unitName){
        //To buy a unit, this method takes a string of that unit name and instantiates that unit, as well as subtracting the mineral and vespene cost from the unit to create it.
        //If that player does not have enough materials for the unit it will play an error
        if(unitName.Equals("Zealot")){
            if(PlayerPrefs.GetInt("player mineral")<50){
                audioSource.PlayOneShot(errorSound);
            }else{
                Players[0].GetComponent<ApplePickerPlayerScript>().mineralCount-=50;
                AudioManager.GetComponent<ApplePickerAudioManagerScript>().RandomClipUnit("Zealot");
                Instantiate(Units[0],Bases[0].transform.position,Quaternion.identity);
            }
        }
        if(unitName.Equals("Stalker")){
            if(PlayerPrefs.GetInt("player mineral")<75 || PlayerPrefs.GetInt("player vespene")<50){
                audioSource.PlayOneShot(errorSound);
            }else{
                Players[0].GetComponent<ApplePickerPlayerScript>().mineralCount-=70;
                Players[0].GetComponent<ApplePickerPlayerScript>().vespeneCount-=50;
                AudioManager.GetComponent<ApplePickerAudioManagerScript>().RandomClipUnit("Stalker");
                Instantiate(Units[1],Bases[0].transform.position,Quaternion.identity);
            }
        }
        if(unitName.Equals("Carrier")){
            if(PlayerPrefs.GetInt("player mineral")<225 || PlayerPrefs.GetInt("player vespene")<300){
                audioSource.PlayOneShot(errorSound);
            }else{
                Players[0].GetComponent<ApplePickerPlayerScript>().mineralCount-=225;
                Players[0].GetComponent<ApplePickerPlayerScript>().vespeneCount-=300;
                AudioManager.GetComponent<ApplePickerAudioManagerScript>().RandomClipUnit("Carrier");
                Instantiate(Units[2],Bases[0].transform.position,Quaternion.identity);
            }
        }
        if(unitName.Equals("Marine")){
            if(PlayerPrefs.GetInt("enemy mineral")>=25){
                Players[1].GetComponent<ApplePickerEnemyScript>().mineralCount-=25;
                Instantiate(Units[3],Bases[1].transform.position,Quaternion.identity);
            }
        }
        if(unitName.Equals("SiegeTank")){
            if(PlayerPrefs.GetInt("enemy mineral")>=50 && PlayerPrefs.GetInt("enemy vespene")>=25){
                Players[1].GetComponent<ApplePickerEnemyScript>().mineralCount-=50;
                Players[1].GetComponent<ApplePickerEnemyScript>().vespeneCount-=25;
                Instantiate(Units[4],Bases[1].transform.position,Quaternion.identity);
            }
        }
        if(unitName.Equals("Battlecruiser")){
            if(PlayerPrefs.GetInt("enemy mineral")>=100 && PlayerPrefs.GetInt("enemy vespene")>=150){
                Players[1].GetComponent<ApplePickerEnemyScript>().mineralCount-=100;
                Players[1].GetComponent<ApplePickerEnemyScript>().vespeneCount-=150;
                Instantiate(Units[5],Bases[1].transform.position,Quaternion.identity);
            }
        }
    }
    // Update is called once per frame
    void Update(){
        if(Bases[0].GetComponent<ApplePickerUnit>().baseDeath){
            enemyWin = true;
        }else if(Bases[1].GetComponent<ApplePickerUnit>().baseDeath){
            playerWin = true;
        }
        //String is entered for the enemy to access the buyunits method from the EnemyBuy method
        BuyUnit(Players[1].GetComponent<ApplePickerEnemyScript>().EnemyBuy());
    }
}
