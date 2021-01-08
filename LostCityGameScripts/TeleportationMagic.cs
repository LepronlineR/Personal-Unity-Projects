using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationMagic : MonoBehaviour
{
    public GameObject enterSpace;
    public Transform teleportLocation;
    public GameObject player;
    public bool autoTP;
    public GameObject revealChange;
    public GameObject playOnce;

    private void OnTriggerStay2D(Collider2D other){
        if(Input.GetKeyDown(KeyCode.E) && !autoTP && other.name == player.name){
            if(revealChange != null){
                revealChange.SetActive(true);
                if(playOnce!=null)
                    playOnce.GetComponent<PlaySoundOnce>().PlayOnce();
            }
            player.transform.position = teleportLocation.position;
        }
        if(autoTP){
            player.transform.position = teleportLocation.position;
        }
    }

}
