using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerTeleporter : MonoBehaviour
{
    [SerializeField] Transform pos;
    private GameObject player;
    private GameObject ac; // audio controller
    private GameObject boss;

    void Start(){
        player = GameObject.Find("Player");
        ac = GameObject.Find("AudioController");
        boss = GameObject.Find("TheBoss");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("Player")){
            player.transform.position = pos.position;
            ac.GetComponent<PlatformerSoundController>().Boss();
            boss.GetComponent<PlatformerBoss>().StartCoroutine("Begin");
        }
    }

}
