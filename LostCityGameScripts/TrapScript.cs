using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public string trapName;
    public Animator anim;
    // Start is called before the first frame update
    void Start(){
        anim.enabled = true;
        anim.SetBool("SteppedOn",false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        anim.SetBool("SteppedOn",true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
