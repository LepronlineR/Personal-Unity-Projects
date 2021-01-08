using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepCounter : MonoBehaviour
{
    public GameObject player;
    private int totalSteps;
    // Update is called once per frame
    void Start(){
        totalSteps = 0;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            totalSteps = 0;
            this.GetComponent<Text>().text = "Steps Taken: "+totalSteps;
        }
    }
    void FixedUpdate() {
        if(player.GetComponent<PlayerManager>().ReturnSpeed()>0){
            totalSteps+=1;
            this.GetComponent<Text>().text = "Steps Taken: "+totalSteps/5;
        }
    }
}
