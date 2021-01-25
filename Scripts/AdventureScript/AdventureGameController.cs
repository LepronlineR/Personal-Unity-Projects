using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
662007329
Zhi Zheng
*/

public class AdventureGameController : MonoBehaviour
{
    public GameObject PlayerPositionText;
    public GameObject LaserLookText;
    public GameObject DoorLocationText;
    public GameObject Player;
    public GameObject Enemy;
    public GameObject Door;
    public AudioSource AudioSource;


    void Start(){
        PlayerPrefs.SetInt("Ore Adventure",0);
        //Begin by setting all default positions and create the random spawn for door
        LaserLookText.GetComponent<Text>().text = "Laser is at looking UP";
        PlayerPositionText.GetComponent<Text>().text = "Player is at Position: " + ((int) Player.GetComponent<Transform>().position.x) + ", " + ((int) Player.GetComponent<Transform>().position.y);
        Door.transform.position = new Vector2(Random.Range(8,-8),Random.Range(5,-5));
        //Setup the Audio
        AudioSource.GetComponent<AudioSource>().volume = 0.132f;
    }

    // Update is called once per frame
    void Update(){
        GeneralUI();
        AudioDoor();
    }

    void GeneralUI(){
        //Updates the player position
        PlayerPositionText.GetComponent<Text>().text = "Player is at Position: " + ((int) Player.GetComponent<Transform>().position.x) + ", " + ((int) Player.GetComponent<Transform>().position.y);
        //Debug.Log((int) Player.GetComponent<Transform>().position.x+","+(int) Player.GetComponent<Transform>().position.y);
        //Test when the player touches the door, and then the location is revealed to the players
        if((int)Player.GetComponent<Transform>().position.x == (int)Door.GetComponent<Transform>().position.x && (int)Player.GetComponent<Transform>().position.y == (int)Door.GetComponent<Transform>().position.y)
            DoorLocationText.GetComponent<Text>().text = "Door is at Location: " + ((int) Door.GetComponent<Transform>().position.x) + ", " + ((int) Door.GetComponent<Transform>().position.y);
    }

    void AudioDoor(){
        Vector2 DSMVector = new Vector2(Player.transform.position.x - Door.transform.position.x, Player.transform.position.y - Door.transform.position.y);
        /*
            (1/5)*1/Vector gives us the formula for the sound when it approaches the Door. When the Vector, which is the change of 
            the player and door, gives us a small vector, the sound increases due to the inverse proportionality *idk how to spell that word*
            Then the audio source is updated in real time.
        */
        AudioSource.GetComponent<AudioSource>().volume = 1/(DSMVector.magnitude*5);
    }

    public void OnClick(string s){
        //Updates the laser position
        if(s.Equals("UP"))
            LaserLookText.GetComponent<Text>().text = "Laser is at looking UP";
        else if(s.Equals("RIGHT"))
            LaserLookText.GetComponent<Text>().text = "Laser is at looking RIGHT";
        else if(s.Equals("LEFT"))
            LaserLookText.GetComponent<Text>().text = "Laser is at looking LEFT";
        else if(s.Equals("DOWN"))
            LaserLookText.GetComponent<Text>().text = "Laser is at looking DOWN";
    }
}
