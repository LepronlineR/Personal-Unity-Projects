using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlatformerMenuController : MonoBehaviour
{
    public GameObject HighScoreText;
    private GameObject player;
    private string dev;
    [SerializeField] GameObject cheat;


    void Start(){
        dev = PlayerPrefs.GetString("Devmode");
        player = GameObject.Find("Player");
        if(HighScoreText!=null){
            ShowHighScore();
        }
        if(cheat!=null){
            if(dev.Equals("on")){
                cheat.SetActive(true);
            } else if(dev.Equals("off"))
                cheat.SetActive(false);
            else
                cheat.SetActive(false);
        }
    }

    void ShowHighScore(){
        float high = PlayerPrefs.GetFloat("High Score Platformer");
        string minute = Mathf.Floor((high%3600)/60).ToString("00");
        string second = (high%60).ToString("00");
        HighScoreText.GetComponent<Text>().text = ("High Score: "+minute+":"+second);
    }

    public void Menu(){
        SceneManager.LoadScene(11);
    }

    public void StartGame(){
        SceneManager.LoadScene(10);
    }

    public void Quit(){
        SceneManager.LoadScene(0);
    }

    public void GainLife(){
        player.GetComponent<PlatformerPlayerController>().life+=999;
    }
}
