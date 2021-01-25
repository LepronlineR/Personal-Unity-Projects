using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerTrapPlatform : MonoBehaviour
{
    Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag.Equals("Player")){
            Invoke("Drop",0.5f);
            Destroy(gameObject, 2.0f);
        }
    }

    void Drop(){
        rb.isKinematic = false;
    }

}
