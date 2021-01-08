using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public GameObject player;
    private int treasure;
    public GameObject text;
    [SerializeField] int treasureNeeded;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == player.name){
            treasure = player.GetComponent<PlayerManager>().treasureCount;
            int newTreasure = treasureNeeded-treasure;
            if(treasure < treasureNeeded && newTreasure!=1){
                text.SetActive(true);
                text.GetComponent<TextMesh>().text = "You still need "+ (newTreasure)  +" treasures!";
            }else if(newTreasure == 1){
                text.SetActive(true);
                text.GetComponent<TextMesh>().text = "You need one more treasure!";
            } else {
                text.SetActive(true);
                text.GetComponent<TextMesh>().text = "You win!";
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        text.SetActive(false);
    }
}
