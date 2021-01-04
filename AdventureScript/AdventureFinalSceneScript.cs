using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
662007329
Zhi Zheng
*/

public class AdventureFinalSceneScript : MonoBehaviour
{
    public GameObject WinningStatement;
    // Start is called before the first frame update
    void Start(){
        int Ores = PlayerPrefs.GetInt("Ore Adventure");
        int HighOres = PlayerPrefs.GetInt("High Score Adventure");
        if(HighOres<Ores){
            PlayerPrefs.SetInt("High Score Adventure", Ores);
        }
        WinningStatement.GetComponent<Text>().text = "Before you escaped you got up to: "+ Ores +" Ores.";;
    }
    //Restarts the game at the win condition and sets the ore amount back to zero
    public void MainMenuBack(){
        PlayerPrefs.SetInt("Ore",0);
        SceneManager.LoadScene(0);
    }
}
