using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
662007329
Zhi Zheng
*/

public class ApplePickerGameManagerScript : MonoBehaviour
{
    public GameObject[] MineralVespeneText;
    public GameObject BaseOP;
    public GameObject Player;
    public GameObject Enemy;
    public GameObject HighScoreDisplay;
    private float savedTime;
    private int speed;

    void Start(){
        speed = 1;
        ShowHighScore();
    }

    void Update(){
        UIUpdateTask();
        //timer
        savedTime += Time.deltaTime * speed;
        //load the scene once the baseoperationscript has detected one base that fell
        if(BaseOP.GetComponent<ApplePickerBaseOperationsScript>().enemyWin){
            SceneManager.LoadScene(5);
        }else if(BaseOP.GetComponent<ApplePickerBaseOperationsScript>().playerWin){
            SceneManager.LoadScene(4);
            SaveHighScore();
        }
    }


    void UIUpdateTask(){
        //Change the in game text of the materials
        MineralVespeneText[0].GetComponent<Text>().text = "Minerals: " + PlayerPrefs.GetInt("player mineral");
        MineralVespeneText[1].GetComponent<Text>().text = "Vespene: " + PlayerPrefs.GetInt("player vespene");
        MineralVespeneText[2].GetComponent<Text>().text = "Minerals: " + PlayerPrefs.GetInt("enemy mineral");
        MineralVespeneText[3].GetComponent<Text>().text = "Vespene: " + PlayerPrefs.GetInt("enemy vespene");
    }

    void ShowHighScore(){
        // get the high score 
        float high = PlayerPrefs.GetFloat("High Score ApplePicker");
        string minute = Mathf.Floor((high%3600)/60).ToString("00");
        string second = (high%60).ToString("00");
        HighScoreDisplay.GetComponent<Text>().text = ("High Score: "+minute+":"+second);
    }
    void SaveHighScore(){
        //save the high score, or if it is the first time then have the first score as the high score
        float high = PlayerPrefs.GetFloat("High Score ApplePicker");
        if(high>savedTime || high==0.0f){
            PlayerPrefs.SetFloat("High Score ApplePicker",savedTime);
        }
    }
}
