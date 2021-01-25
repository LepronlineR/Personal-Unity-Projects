using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
662007329
Zhi Zheng
*/

public class AdventurePlayerController : MonoBehaviour
{
    public int speed;
    public GameObject GameController;
    public AudioSource AudioSource;
    public AudioClip WallSound;
    private Vector2 CombinedSpeed;

    // Update is called once per frame
    void Update(){
        InputCommand(WallCollider());
        Movement();
        //Debug.Log((int) transform.position.x + "," + (int) transform.position.y);
    }
    void InputCommand(string str){
        //Input movement for the player and uses string to tell if path is blocked, then making it unable to pass **definitely the most inefficient way to do this**
        CombinedSpeed = Vector2.zero;
        if(Input.GetKey(KeyCode.W) && !str.Equals("NOUP") && !str.Equals("NORTNOUP") && !str.Equals("NOLTNOUP") && !str.Equals("NOUPNORT") && !str.Equals("NOUPNOLT"))
            CombinedSpeed += Vector2.up;
        if(Input.GetKey(KeyCode.A) && !str.Equals("NOLT") && !str.Equals("NOLTNOUP") && !str.Equals("NOLTNODO") && !str.Equals("NOUPNOLT") && !str.Equals("NODONOLT"))
            CombinedSpeed += Vector2.left;
        if(Input.GetKey(KeyCode.S) && !str.Equals("NODO") && !str.Equals("NORTNODO") && !str.Equals("NOLTNODO") && !str.Equals("NODONORT") && !str.Equals("NODONOLT"))
            CombinedSpeed += Vector2.down;
        if(Input.GetKey(KeyCode.D) && !str.Equals("NORT") && !str.Equals("NORTNODO") && !str.Equals("NOUPNORT") && !str.Equals("NODONORT") && !str.Equals("NORTNOUP"))
            CombinedSpeed += Vector2.right;
    }
    void Movement(){
        //perform the movement inputted by the player
        transform.Translate(CombinedSpeed*speed*Time.deltaTime);
    }

    string WallCollider(){
        //return string to test if there is a blocked path

        /*
            To make sure that the corners are tested, for each instance of the position.x, the other position.y has to be tested. Originally it can be overlooked and shorted, but in this case, 
            coming from a certain direction "y" or "x" and those instances are not tested, then it will be passable from the incoming direction. Therefore, all corner cases with 
            the starting case (x) or (y) must be tested.
            - Nested loop if(PosX > 8) then if(PosY > 4) and Nested loop if(PosY > 4) then if(PosX > 8).

            The wall sound plays multiple times loudly when put in the nested loop. Therefore, I used a method (PlayOneShot) to throw one sound loop while colliding with the wall
        */
        int PosX = (int) transform.position.x;
        int PosY = (int) transform.position.y;
        if(PosX > 8){
            if(!AudioSource.isPlaying)
                AudioSource.PlayOneShot(WallSound, 1);
            if(PosY > 4)
                return "NORTNOUP";
            if(PosY < -4)
                return "NORTNODO";
            return "NORT";
        }
        if(PosX < -8){
            if(!AudioSource.isPlaying)
                AudioSource.PlayOneShot(WallSound, 1);
            if(PosY > 4)
                return "NOLTNOUP";
            if(PosY < -4)
                return "NOLTNODO";
            return "NOLT";
        }
        if(PosY > 4){
            if(!AudioSource.isPlaying)
                AudioSource.PlayOneShot(WallSound, 1);
            if(PosX > 8)
                return "NOUPNORT";
            if(PosX < -8)
                return "NODONORT";
            return "NOUP";
        }
        if(PosY < -4){
            if(!AudioSource.isPlaying)
                AudioSource.PlayOneShot(WallSound, 1);
            if(PosX > 8)
                return "NOUPNOLT";
            if(PosX < -8)
                return "NODONOLT";
            return "NODO";
        }
        return "";
    }
}
