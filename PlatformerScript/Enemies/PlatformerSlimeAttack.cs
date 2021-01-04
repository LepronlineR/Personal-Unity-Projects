using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerSlimeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private float force;
    private GameObject player;
    private Rigidbody2D rb;
    
    void Start(){
        force = 1750.0f;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        Vector3 aim = (player.transform.position-transform.position).normalized;
        rb.AddForce(aim * force);
    }

    private void OnBecameInvisible(){
        Destroy(gameObject);
    }

}
