using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerGrounded : MonoBehaviour
{
    private GameObject pc; 
    public bool grounded;

    void Start(){
        pc = GameObject.Find("Main Camera");
    }

    void Update(){
        if(grounded){
            pc.GetComponent<PlatformerCamera>().MoveCameraToPos(this.transform);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("Ground")){
            grounded = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag.Equals("Ground")){
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        grounded = false;
    }
}
