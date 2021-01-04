using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
662007329
Zhi Zheng
*/

public class ApplePickerWinScript : MonoBehaviour
{
    public GameObject HighScoreText;
    // Start is called before the first frame update
    void Start(){
        ShowHighScore();
    }
    void ShowHighScore(){
        //display the high score
        float high = PlayerPrefs.GetFloat("High Score ApplePicker");
        string minute = Mathf.Floor((high%3600)/60).ToString("00");
        string second = (high%60).ToString("00");
        HighScoreText.GetComponent<Text>().text = ("High Score: "+minute+":"+second);
    }
    public void ReturnToMenu(){
        //load menu screen
        SceneManager.LoadScene(0);
    }

}
