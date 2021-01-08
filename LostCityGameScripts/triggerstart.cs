using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerstart : MonoBehaviour
{
    public GameObject GlobalLight;
    public GameObject Player;
    public Transform newPos;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == Player.name){
            GlobalLight.SetActive(false);
            Player.transform.position = newPos.position;
        }
    }
}
