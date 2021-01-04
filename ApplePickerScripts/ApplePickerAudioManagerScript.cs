using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
662007329
Zhi Zheng
*/

public class ApplePickerAudioManagerScript : MonoBehaviour
{
    private int randomNumber;
    public AudioSource audioSource;
    public AudioClip[] backgroundMusic;
    public AudioClip[] probeSound;
    public AudioClip[] unitSound;
    // Start is called before the first frame update
    void Start(){
        //pick the BGM and loop it
        audioSource.loop = true;
        audioSource.clip = RandomClipBG();
        audioSource.Play();
    }

    private AudioClip RandomClipBG(){
        //set random BGM
        return backgroundMusic[Random.Range(0,backgroundMusic.Length)];
    }

    private AudioClip RandomClipProbe(){
        //return random probe clip sound
        return probeSound[Random.Range(0,probeSound.Length)];
    }
    public void PlayRandomClipProbe(){
        //play random probe clip sound
        audioSource.PlayOneShot(RandomClipProbe());
    }

    public void RandomClipUnit(string unit){
        //from the pattern of inputted clips, it will randomzie a clip and play it
        if(unit.Equals("Zealot")){
            audioSource.PlayOneShot(unitSound[Random.Range(0,3)]);
        }
        if(unit.Equals("Stalker")){
            audioSource.PlayOneShot(unitSound[Random.Range(3,6)]);
        }
        if(unit.Equals("Carrier")){
            audioSource.PlayOneShot(unitSound[Random.Range(6,9)]);
        }
    }
}
