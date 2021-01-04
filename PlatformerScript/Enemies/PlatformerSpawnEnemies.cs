using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerSpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    void Start(){
        enemy.SetActive(false);
    }

    void Update(){
        if(enemy==null){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("Player"))
            enemy.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag.Equals("Player"))
            enemy.SetActive(false);
    }

    /*private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }*/
}
