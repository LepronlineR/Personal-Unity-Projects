using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenuScript : MonoBehaviour
{
    public VideoClip[] videos;
    public GameObject videoManager;
    public GameObject[] highScoreText;

    void Start(){
        PlayerPrefs.SetString("Devmode","off");
        ShowHighScoreApplePicker();
        ShowHighScoreSHMUP();
        ShowHighScorePlatformer();
        highScoreText[0].GetComponent<Text>().text = "Ores: "+PlayerPrefs.GetInt("High Score Adventure");
    }
    void ShowHighScoreApplePicker(){
        //display the high score with time
        float high = PlayerPrefs.GetFloat("High Score ApplePicker");
        string minute = Mathf.Floor((high%3600)/60).ToString("00");
        string second = (high%60).ToString("00");
        highScoreText[1].GetComponent<Text>().text = ("Time: "+minute+":"+second);
    }

    void ShowHighScoreSHMUP(){
         //display the high score with time
        float high = PlayerPrefs.GetFloat("High Score SHMUP");
        string minute = Mathf.Floor((high%3600)/60).ToString("00");
        string second = (high%60).ToString("00");
        highScoreText[2].GetComponent<Text>().text = ("Time: "+minute+":"+second);
    }

    void ShowHighScorePlatformer(){
         //display the high score with time
        float high = PlayerPrefs.GetFloat("High Score Platformer");
        string minute = Mathf.Floor((high%3600)/60).ToString("00");
        string second = (high%60).ToString("00");
        highScoreText[3].GetComponent<Text>().text = ("Time: "+minute+":"+second);
    }

    //load scenes for the games
    public void AdventureGame(){
        SceneManager.LoadScene(1);
    }
    public void ApplePickerGame(){
        SceneManager.LoadScene(3);
    }
    public void SHMUPGame(){
        SceneManager.LoadScene(6);
    }
    public void PlatformerGame(){
        SceneManager.LoadScene(11);
    }

    //loads the preview video for the games
    public void AdventureVideo(){
        videoManager.GetComponent<VideoPlayer>().clip = videos[0];
    }
    public void ApplePickerVideo(){
        videoManager.GetComponent<VideoPlayer>().clip = videos[1];
    }
    public void SHMUPVideo(){
        videoManager.GetComponent<VideoPlayer>().clip = videos[2];
    }
    public void PlatformerVideo(){
        videoManager.GetComponent<VideoPlayer>().clip = videos[3];
    }

    //turn dev mode on for the game! Experimental 
    public void EnableDevMode(bool devOn){
        if(devOn){
            Debug.Log("Dev on");
            PlayerPrefs.SetString("Devmode","on");
        } else {
            Debug.Log("Dev off");
            PlayerPrefs.SetString("Devmode","off");
        }
    }
}
