using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillarManager : MonoBehaviour
{
    public GameObject UIinteractable;
    private bool alreadyAct;
    public AudioSource rockPush;
    public Transform newRespawnPoint;
    public GameObject Player;
    public GameObject Arrows;
    public GameObject[] traps;
    public GameObject pos;
    private Vector2 normalVector;

    void Start(){
        alreadyAct = false;
        UIinteractable.SetActive(false);
        Arrows.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(!alreadyAct&&other.name == Player.name){
            UIinteractable.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(!alreadyAct&&Input.GetKeyDown(KeyCode.E)&&other.name == Player.name){
            Player.GetComponent<PlayerManager>().respawnPoint = newRespawnPoint;
            Player.GetComponent<PlayerManager>().tddsHave+=1;
            
            alreadyAct = true;
            rockPush.Play();
            UIinteractable.SetActive(false);
            foreach(GameObject t in traps){
                Vector2 trapV = new Vector2(t.GetComponent<Transform>().position.x-pos.GetComponent<Transform>().position.x,
                t.GetComponent<Transform>().position.y-pos.GetComponent<Transform>().position.y);
                normalVector = new Vector2(trapV.sqrMagnitude,0.0f);
                float angleT = Vector2.Angle(normalVector,trapV);
                Player.GetComponent<PlayerManager>().storedDegrees.Add((int)angleT);
            }
            Arrows.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.name == Player.name)
            UIinteractable.SetActive(false);
    }
    void Update(){
    }
}
