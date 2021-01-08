using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivationScript : MonoBehaviour
{
    public GameObject trap;
    private IEnumerator beginCor;
    public GameObject death;
    public AudioSource spikeSound;
    public AudioSource fallSound;
    public AudioSource foundTrap;
    public string trapName;

    void OnTriggerEnter2D(Collider2D other){
        if(beginCor == null && other.tag == "Explosion"){
            foundTrap.Play();
            Destroy(this.gameObject);
        }
        if(beginCor == null && other.name == "Player"){
            beginCor = PlayOn();
            StartCoroutine(beginCor);
        }
    }
    IEnumerator PlayOn(){
        if(trapName=="Spike")
            spikeSound.Play();
        if(trapName=="Pitfall")
            fallSound.Play();
        trap.SetActive(true);
        death.GetComponent<DeathScript>().OnDeath(trapName);
        yield return new WaitForSeconds(5.0f);
        beginCor = null;
        if(trapName=="Spike")
            this.gameObject.SetActive(false);
    }
}
