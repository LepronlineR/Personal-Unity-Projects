using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
662007329
Zhi Zheng
*/

public class AdventureEnemyPrefabScript : MonoBehaviour
{
    public GameObject Player;
    public AudioSource AudioSource;
    public AudioClip DeathSound;
    // Start is called before the first frame update
    void Start(){
        //EnemyPos.text = "Enemy is at Position: " + ((int) transform.position.x) + ", " + ((int) transform.position.y);
    }

    // Update is called once per frame
    void Update(){
        CollidesWithPlayer();
        FollowPlayer();
    }
    void CollidesWithPlayer(){
        //If the x and y position of the player and enemy are the same, then the player will get hit
        if(((int)transform.position.y) == ((int) Player.GetComponent<Transform>().position.y) && ((int) transform.position.x) == ((int) Player.GetComponent<Transform>().position.x)){
            if(!AudioSource.isPlaying)
                AudioSource.PlayOneShot(DeathSound, 0.5f);
            DestroyImmediate(Player, true);
        }
    }
    void FollowPlayer(){
        //have a targeted destination, which is the player, and the move toward that player with a low speed
        transform.position = Vector2.MoveTowards(transform.position, Player.GetComponent<Transform>().position, Random.Range(0.006f,0.004f));
        //Debug.Log((int)transform.position.x +", "+(int)transform.position.y);
    }
}
