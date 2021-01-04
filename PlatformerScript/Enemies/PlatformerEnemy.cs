using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerEnemy : MonoBehaviour{
    
    public float health;
    public GameObject player;
    private GameObject dc;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool once;

    protected void Update(){
        if(health<=0&&!once){
            StartCoroutine("OnDeath");
            once = true;
        }
    }

    private void Awake(){
        once = false;
        player = GameObject.Find("Player");
        dc = GameObject.Find("DeathController");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    public IEnumerator OnDeath(){
        StartCoroutine(dc.GetComponent<PlatformerDeathController>().EnemyDeath(sr,this.gameObject));
        yield return null;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other){
        if(other.tag.Equals("playerhitbox")){
            health -= player.GetComponent<PlatformerPlayerController>().damage;
        }
    }

}