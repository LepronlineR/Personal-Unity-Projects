using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseControls : MonoBehaviour
{
    public GameObject menu;
    public GameObject buttonToMenu;
    public bool inMenu;

    void start(){
        inMenu = false;
    }
    public void PauseGame(){
        buttonToMenu.SetActive(false);
        inMenu = true;
        menu.SetActive(inMenu);
        Time.timeScale = 0;
    }

    public void ResumeGame(){
        buttonToMenu.SetActive(true);
        inMenu = false;
        menu.SetActive(inMenu);
        Time.timeScale = 1;
    }

    public void LoadMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void Update(){
        if(Input.GetKey(KeyCode.Escape)&&!inMenu){
            PauseGame();
        }
    }
}
