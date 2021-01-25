using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
662007329
Zhi Zheng
*/

public class ApplePickerDevModeScript : MonoBehaviour
{
    public GameObject[] Bases;
    public GameObject Player;
    private string dev;
    public GameObject openMenuButton;
    public GameObject menuPanel;

    void Start(){
        dev = PlayerPrefs.GetString("Devmode");
        if(dev.Equals("on")){
            openMenuButton.SetActive(true);
        }
        else if(dev.Equals("off"))
            openMenuButton.SetActive(false);
        else
            openMenuButton.SetActive(false);
    }

    public void OpenMenu(){
        openMenuButton.SetActive(false);
        menuPanel.SetActive(true);
    }
    public void CloseMenu(){
        openMenuButton.SetActive(true);
        menuPanel.SetActive(false);
    }
    public void GetMaterials(string s){
        if(s.Equals("playerm")){
            Debug.Log("Mineral Added");
            Player.GetComponent<ApplePickerPlayerScript>().mineralCount = 9999;
        }
        if(s.Equals("playerv")){
            Debug.Log("Vespene Added");
            Player.GetComponent<ApplePickerPlayerScript>().vespeneCount = 9999;
        }
    }
    public void SetBaseHP(string s){
        if(s.Equals("playerb500")){
            Debug.Log("Player Base now 500HP");
            Bases[0].GetComponent<ApplePickerUnit>().health = 500;
        }
        if(s.Equals("playerb1")){
            Debug.Log("Player Base now 1HP");
            Bases[0].GetComponent<ApplePickerUnit>().health = 1;
        }
        if(s.Equals("enemyb500")){
            Debug.Log("Enemy Base now 500HP");
            Bases[1].GetComponent<ApplePickerUnit>().health = 500;
        }
        if(s.Equals("enemyb1")){
            Debug.Log("Enemy Base now 1HP");
            Bases[1].GetComponent<ApplePickerUnit>().health = 1;
        }
    }
    public void TimeChange(string s){
        if(s.Equals("fast")){
            Time.timeScale = 2.0f;
        }
        if(s.Equals("slow")){
            Time.timeScale = 0.25f;
        }
        if(s.Equals("normal")){
            Time.timeScale = 1.0f;
        }
    }
}
