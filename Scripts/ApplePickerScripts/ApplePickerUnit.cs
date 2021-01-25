using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
662007329
Zhi Zheng
*/

public class ApplePickerUnit : MonoBehaviour
{
    public int health;
    public int damage;
    public int mineralCost;
    public int vespeneCost;
    public string unitName;
    private Coroutine DPScount;
    private Vector2 speed;
    public bool baseDeath;
    private Vector2 stopVelocity;

    void Start(){
        stopVelocity = new Vector2(0.0f, 0.0f);
        baseDeath = false;
        FindVelocity();
    }

    void Update(){
        //if this unit dies, then there coroutine has to be stopped, and the object will be destroyed
        if(health <= 0){
            DPScount = null;
            if(unitName.Equals("Base")){
                baseDeath = true;
            }
            Destroy(this.gameObject);
        }
    }

    //this used to define the velocity of every unit
    void FindVelocity(){
        switch(unitName){
            case "Zealot":
                speed = new Vector2(1.25f, 0.0f);
                break;
            case "Marine":
                speed = new Vector2(-1.25f, 0.0f);
                break;
            case "Stalker":
                speed = new Vector2(2.0f, 0.0f);
                break;
            case "SiegeTank":
                speed = new Vector2(-1.5f, 0.0f);
                break;
            case "Carrier":
                speed = new Vector2(0.5f, 0.0f);
                break;
            case "Battlecruiser":
                speed = new Vector2(-0.5f, 0.0f);
                break;
        }
        this.GetComponent<Rigidbody2D>().velocity = speed;
    }
    //For every on trigger stay, the detection system will have to detect the opposites, and then the unit velocity of both will be stopped. 
    //Then a coroutine will start with the units returning their dps to each other 
    //while loop is to make sure the on trigger stay does not iterate multiple times while the 0 velocity stays constant
    void OnTriggerStay2D(Collider2D collision){
        if(collision.tag.Equals("Terran") && this.tag.Equals("Protoss") || collision.tag.Equals("Protoss") && this.tag.Equals("Terran")){
            this.GetComponent<Rigidbody2D>().velocity = stopVelocity;
            while(DPScount == null){
                DPScount = StartCoroutine(DamagePerSecond(collision.gameObject));
            }
        }
    }

    //when the trigger ends the velocity of the unit will return and the on trigger command DPScount will have to be null for the loop to trigger
    void OnTriggerExit2D(){
        DPScount = null;
        FindVelocity();
    }

    //The coroutine defines if the gameobject exists, and then will return damage equal to the unit's health
    IEnumerator DamagePerSecond(GameObject other){
        while(other!=null){
            yield return new WaitForSeconds(0.2f);
            health -= other.GetComponent<ApplePickerUnit>().returnDamage();
        }
    }
    int returnDamage(){
        return damage;
    }

}
