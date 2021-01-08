using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domain : MonoBehaviour
{
    public GameObject stairs;
    public GameObject blockage;
    public GameObject player;
    private bool alrHap;
    // Start is called before the first frame update
    void Start(){
        alrHap = false;
        stairs.SetActive(false);
        blockage.SetActive(true);
    }

    void Update(){
        if(player.GetComponent<PlayerManager>().level == 1&&this.name == "DomainRoom"){
            blockage.SetActive(false);
        }
        if(player.GetComponent<PlayerManager>().level == 2&&this.name == "DomainRoom2"){
            blockage.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!alrHap&&other.name == player.name){
            player.GetComponent<PlayerManager>().level++;
            alrHap = true;
        }
    }

}
