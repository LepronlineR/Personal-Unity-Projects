using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainTreasure : MonoBehaviour
{
    public GameObject player;
    public GameObject texts;
    private bool alreadyHap;
    // Start is called before the first frame update
    void Start(){
        alreadyHap = false;
        texts.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!alreadyHap&&other.name == player.name){
            alreadyHap = true;
            if(this.name != "StartingObtain")
                player.GetComponent<PlayerManager>().treasureCount++;
        }
        if(other.name == player.name && player.GetComponent<PlayerManager>().treasureCount > 1){
            texts.GetComponent<TextMesh>().text = "You have "+player.GetComponent<PlayerManager>().treasureCount+" treasures";
        } else if(other.name == player.name && player.GetComponent<PlayerManager>().treasureCount == 1){
            texts.GetComponent<TextMesh>().text = "You only have 1 treasure";
        } else if(other.name == player.name && player.GetComponent<PlayerManager>().treasureCount == 0){
            texts.GetComponent<TextMesh>().text = "You don't have any treasure";
        }
        texts.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.name == player.name){
            texts.SetActive(false);
        }
    }
}
