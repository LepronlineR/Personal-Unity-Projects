using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerSmartEnemy : PlatformerEnemy{

    //this enemy shoots at the player based on a certain radius

    private Animator anim;
    [SerializeField] GameObject slimeAttack;

    void Start(){
        anim = GetComponent<Animator>();
    }

    private void OnEnable(){
        StartCoroutine("Attack");
    }
    private void OnDisable() {
        StopCoroutine("Attack");
    }

    IEnumerator Attack(){
        while(true){
            yield return new WaitForSeconds(3.0f);
            anim.SetBool("Attack",true);
            Instantiate(slimeAttack, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("Attack",false);
        }
    }

}
