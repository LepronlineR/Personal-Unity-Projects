using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 movement;
    public Animator anim;
    public GameObject death;
    public Transform respawnPoint;
    public int treasureCount;
    private bool devMode;
    public int level;
    public List<int> storedDegrees;
    public GameObject canvas;
    private bool pressedI;
    public GameObject degreeText;
    public bool updateDegreeText;
    public GameObject TDDMan;
    public GameObject crosshair;
    public int tddsHave;
    public bool inventoryActive;

    // Start is called before the first frame update
    void Start(){
        inventoryActive = false;
        crosshair.SetActive(false);
        updateDegreeText = false;
        storedDegrees = new List<int>();
        level = 0;
        devMode = false;
        treasureCount = 0;
        moveSpeed = 5.0f;
        respawnPoint.position = new Vector3(0.0f, 0.0f, transform.position.z);
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.I)){
            degreeText.GetComponent<Text>().text = "";
            foreach(int x in storedDegrees){
                degreeText.GetComponent<Text>().text += x+", ";
            }
            if(!pressedI){
                inventoryActive = true;
                canvas.SetActive(true);
                crosshair.SetActive(true);
                pressedI = true;
            } else {
                inventoryActive = false;
                canvas.SetActive(false);
                crosshair.SetActive(false);
                pressedI = false;
            }

        }
        if(Input.GetKeyDown(KeyCode.G)){
            if(!devMode){
                devMode = true;
            } else {
                devMode = false;
            }
        }
        if(devMode){
            if(Input.GetKeyDown(KeyCode.U))
                death.GetComponent<DeathScript>().OnDeath("Spike");
            if(Input.GetKeyDown(KeyCode.Y))
                treasureCount++;
            if(Input.GetKeyDown(KeyCode.H))
                treasureCount--;
                
        }
        /*
        if(Input.GetKeyDown(KeyCode.T)){
            death.GetComponent<DeathScript>().OnDeath();
        }
        if(Input.GetKeyDown(KeyCode.Y)){
            death.GetComponent<DeathScript>().SetRespawn();
        } */
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public float ReturnSpeed(){
        return movement.sqrMagnitude;
    }
}
