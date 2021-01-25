using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerDeathController : MonoBehaviour
{
    [SerializeField] GameObject blood;

    private GameObject player;
    private Color colorinv;
    private Color colorreg;
    private Renderer render;

    void Start(){
        player = GameObject.Find("Player");
        render = player.GetComponent<Renderer>();
        colorinv = render.material.color;
        colorreg = render.material.color;
        colorinv.a = 0.5f;
        colorreg.a = 1.0f;
    }

    public void Death(string name){
        if(name.Equals("player")){
            StartCoroutine("PlayerDeath");
        }
    }


    IEnumerator PlayerDeath(){
        player.GetComponent<PlatformerPlayerController>().PlayerDeathBoolFalse();
        GameObject bloodinstantiate = (GameObject) Instantiate(blood, player.GetComponent<Transform>().position, Quaternion.identity);
        //this is taken from the SHMUP game (player flickers and has invincibility)
        yield return new WaitForSeconds(0.5f);
        player.SetActive(true);
        //10 is player collision, 14 is enemy collision
        //set to ignore collision and then change colors to transparent
        //after a few seconds 
        Physics2D.IgnoreLayerCollision(10,14,true);
        Physics2D.IgnoreLayerCollision(10,14,true);
        //flickering effect for invicibility after death
        for(int x=0; x<6; x++){
            if(x%2==0){
                render.material.color = colorinv;
            } else {
                render.material.color = colorreg;
            }
            yield return new WaitForSeconds(0.50f); // 0.75 * 4 = 3 seconds
        }
        Destroy(bloodinstantiate);
        Physics2D.IgnoreLayerCollision(10,14,false);
        Physics2D.IgnoreLayerCollision(10,14,false);
    }

    public IEnumerator EnemyDeath(SpriteRenderer sr, GameObject emy){
        GameObject bloodinstantiate = (GameObject) Instantiate(blood, emy.GetComponent<Transform>().position, blood.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        for(float x=1.0f; x >=0.0f; x-= 0.05f){
            Color c = sr.material.color;
            c.a = x;
            sr.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(bloodinstantiate);
        Destroy(emy);
    }
}
