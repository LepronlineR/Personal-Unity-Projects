using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
662007329
Zhi Zheng
*/

public class AdventureOrePrefab : MonoBehaviour
{
    public GameObject LaserLookText;
    public GameObject Player;
    public GameObject OP;
    public GameObject OreLocationText;
    public GameObject Door;
    public AudioSource AudioSource;
    public AudioClip Laser;
    public Button button;
    private int random;
    private bool click;
    private string[] directions;
    private static int OreAmount;

    void Start(){
        directions = new string[] {"UP", "RIGHT", "LEFT", "DOWN"};
        random = Random.Range(0,3);
        transform.position = new Vector2(Random.Range(8,-8),Random.Range(5,-5));
        OreLocationText.GetComponent<Text>().text = "Location of Ore: " + (int) transform.position.x + ", " + (int) transform.position.y +". Mine "+ directions[random] + "  Total Ores: "+OreAmount;
        button.GetComponent<Button>().onClick.AddListener(OnClickLaserButton);
    }

    // Update is called once per frame
    void Update()
    {
        //Win if the player gets at least 5 ores
        if(OreAmount>=5 && (int)Player.GetComponent<Transform>().position.x == (int)Door.GetComponent<Transform>().position.x && (int)Player.GetComponent<Transform>().position.y == (int)Door.GetComponent<Transform>().position.y){
            PlayerPrefs.SetInt("Ore Adventure",OreAmount);
            SceneManager.LoadScene(2);
        }
        //Uses the collideswithplayer method to then create a new ore in a new location and destorying the old one
        if(CollidesWithPlayer()){
            OreAmount++;
            GameObject OPrefab = Instantiate(OP) as GameObject;
            OPrefab.GetComponent<AdventureOrePrefab>();
            OPrefab.transform.position = new Vector2(Random.Range(8,-8),Random.Range(5,-5));
            DestroyImmediate(this, true);
        }
        click = false;
    }
    public void OnClickLaserButton(){
        if(!AudioSource.isPlaying)
            AudioSource.PlayOneShot(Laser, 1);
        click = true;
    }

    bool CollidesWithPlayer(){
        //Gets the collision of the player through similar position of the ore and player and then when the button is clicked, then the collision will return true and add onto an ore picked
        if((int) transform.position.x == (int) Player.GetComponent<Transform>().position.x && (int) transform.position.y == (int) Player.GetComponent<Transform>().position.y){
            switch(random){
                case 0:
                    if(click&&LaserLookText.GetComponent<Text>().text.Equals("Laser is at looking UP"))
                        return true;
                    break;
                case 1:
                    if(click&&LaserLookText.GetComponent<Text>().text.Equals("Laser is at looking RIGHT"))
                        return true;
                    break;
                case 2:
                    if(click&&LaserLookText.GetComponent<Text>().text.Equals("Laser is at looking LEFT"))
                        return true;
                    break;
                case 3:
                    if(click&&LaserLookText.GetComponent<Text>().text.Equals("Laser is at looking DOWN"))
                        return true;
                    break;
            }
        }
        return false;
    }
    public int ReturnOre(){
        return OreAmount;
    }
    
}
