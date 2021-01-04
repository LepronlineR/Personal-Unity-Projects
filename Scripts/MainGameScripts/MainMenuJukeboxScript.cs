using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuJukeboxScript : MonoBehaviour
{
    //I figured that the background is very lonely and boring without any chill music playing! Enjoy my playlist :)
    public AudioClip[] jukeboxMusic;
    public AudioSource audioSource;
    public GameObject nowPlaying;
    int random;

    void Start(){
        //pick the BGM and loop it
        audioSource.loop = true;
        random = Random.Range(0,jukeboxMusic.Length);
        audioSource.clip = jukeboxMusic[random];
        nowPlaying.GetComponent<Text>().text = "Now Playing: "+jukeboxMusic[random].name;
        audioSource.Play();
    }

    //dropdown menu for swapping music
    public void ChangeMusic(int change){
        switch(change){
            case 0:
                audioSource.clip = jukeboxMusic[0];
                nowPlaying.GetComponent<Text>().text = "Now Playing: "+jukeboxMusic[0].name;
                audioSource.Play();
                break;
            case 1:
                audioSource.clip = jukeboxMusic[1];
                nowPlaying.GetComponent<Text>().text = "Now Playing: "+jukeboxMusic[1].name;
                audioSource.Play();
                break;
            case 2:
                audioSource.clip = jukeboxMusic[2];
                nowPlaying.GetComponent<Text>().text = "Now Playing: "+jukeboxMusic[2].name;
                audioSource.Play();
                break;
            case 3:
                audioSource.clip = jukeboxMusic[3];
                nowPlaying.GetComponent<Text>().text = "Now Playing: "+jukeboxMusic[3].name;
                audioSource.Play();
                break;
            case 4:
                audioSource.clip = jukeboxMusic[4];
                nowPlaying.GetComponent<Text>().text = "Now Playing: "+jukeboxMusic[4].name;
                audioSource.Play();
                break;
            case 5:
                audioSource.clip = jukeboxMusic[5];
                nowPlaying.GetComponent<Text>().text = "Now Playing: "+jukeboxMusic[5].name;
                audioSource.Play();
                break;
        }
    }
}
