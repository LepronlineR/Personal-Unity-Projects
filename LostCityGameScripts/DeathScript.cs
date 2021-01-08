using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject blood;
    public GameObject head;
    public GameObject player;
    private IEnumerator startDeath;
    public GameObject lighting;
    public AudioSource deathSound;
    private string deathName;

    public void SetRespawn(){
        player.gameObject.SetActive(true);
        player.transform.position = 
        player.GetComponent<PlayerManager>().respawnPoint.transform.position;
    }

    public void OnDeath(string dN){
        if(startDeath == null){
            deathName = dN;
            if(dN=="Spike")
                startDeath = DeathSpike();
            if(dN=="Pitfall")
                startDeath = DeathPitfall();
            StartCoroutine(startDeath);
        }
    }

    IEnumerator DeathSpike(){
        player.gameObject.SetActive(false);
        deathSound.Play();
        GameObject lightningClone = 
            (GameObject) Instantiate(lighting,player.transform.position,Quaternion.identity);
        GameObject bloodClone = 
            (GameObject) Instantiate(blood,player.transform.position,Quaternion.identity);
        GameObject headClone =
            (GameObject) Instantiate(head,player.transform.position,Quaternion.identity);
        yield return new WaitForSeconds(5.0f);
        SetRespawn();
        Destroy(lightningClone);
        Destroy(bloodClone);
        Destroy(headClone);
        startDeath = null;
    }

    IEnumerator DeathPitfall(){
        player.gameObject.SetActive(false);
        deathSound.Play();
        GameObject lightningClone = 
            (GameObject) Instantiate(lighting,player.transform.position,Quaternion.identity);
        yield return new WaitForSeconds(5.0f);
        SetRespawn();
        Destroy(lightningClone);
        startDeath = null;
    }

}
