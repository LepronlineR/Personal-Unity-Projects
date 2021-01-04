using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerSoundController : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusicplayer;
    [SerializeField] AudioSource swordSwing;
    public AudioClip[] backgroundMusic;
    public AudioClip[] swingSound;

    void Start(){
        backgroundMusicplayer.loop = true;
        backgroundMusicplayer.clip = backgroundMusic[0];
        backgroundMusicplayer.Play();
    }

    public void Boss(){
        backgroundMusicplayer.clip = backgroundMusic[1];
        backgroundMusicplayer.Play();
    }

    public void SwingClip(){
        int r = Random.Range(0, swingSound.Length);
        swordSwing.clip = swingSound[r];
        swordSwing.Play();
    }
}
