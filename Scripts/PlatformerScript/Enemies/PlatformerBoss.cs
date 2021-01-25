using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformerBoss : MonoBehaviour
{
    public float health;
    private GameObject player;
    private SpriteRenderer sr;
    [SerializeField] AudioSource laser;
    [SerializeField] GameObject rainparticles;
    [SerializeField] GameObject raindropletparticles;
    [SerializeField] GameObject rainsound;
    [SerializeField] GameObject thundersound;

    [SerializeField] GameObject[] meteors;
    [SerializeField] GameObject[] meteorspawnpoint;

    [SerializeField] GameObject[] lasers;
    [SerializeField] GameObject[] laserwarnings;

    [SerializeField] GameObject lasertext;
    [SerializeField] GameObject meteortext;
    [SerializeField] GameObject pretext;

    void Start(){
        sr = GetComponent<SpriteRenderer>();
        health = 650.0f;
        player = GameObject.Find("Player");
        rainparticles.SetActive(false);
        raindropletparticles.SetActive(false);
        rainsound.SetActive(false);
        thundersound.SetActive(false);
        Color c = sr.material.color;
        c.a = 0.0f;
        sr.material.color = c;
    }

    void Update(){
        if(health<=0){
            SceneManager.LoadScene(13);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag.Equals("playerhitbox")){
            health -= player.GetComponent<PlatformerPlayerController>().damage;
        }
    }

    public IEnumerator Begin(){
        rainparticles.SetActive(true);
        raindropletparticles.SetActive(true);
        rainsound.SetActive(true);
        thundersound.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        for(float x=0.0f; x <=1.0f; x+= 0.005f){
            Color c = sr.material.color;
            c.a = x;
            sr.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        pretext.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        pretext.SetActive(false);
        StartCoroutine(MeteorDevestation());
    }

    IEnumerator LaserBlow(){
        lasertext.SetActive(true);
        //fires laser at side and then middle, warning
        yield return new WaitForSeconds(5.0f);
        lasertext.SetActive(false);
        //side warning and then laser follows
        laserwarnings[1].SetActive(true);
        laserwarnings[2].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        laser.Play();
        yield return new WaitForSeconds(0.5f);
        laserwarnings[1].SetActive(false);
        laserwarnings[2].SetActive(false);
        lasers[1].SetActive(true);
        lasers[2].SetActive(true);
        yield return new WaitForSeconds(3.0f);
        lasers[1].SetActive(false);
        lasers[2].SetActive(false);

        yield return new WaitForSeconds(1.0f);
        //middle warning and the laser follows
        laserwarnings[0].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        laser.Play();
        yield return new WaitForSeconds(0.5f);
        laserwarnings[0].SetActive(false);
        lasers[0].SetActive(true);
        yield return new WaitForSeconds(3.0f);
        lasers[0].SetActive(false);
        StartCoroutine(MeteorDevestation());
    }

    IEnumerator MeteorDevestation(){
        meteortext.SetActive(true);
        //multiple meteors fall from the sky
        List<GameObject> ms = new List<GameObject>();
        yield return new WaitForSeconds(5.0f);
        meteortext.SetActive(false);
        foreach(GameObject g in meteorspawnpoint){
            int r = Random.Range(0,meteors.Length);
            GameObject mdm = (GameObject) Instantiate(meteors[r],g.transform.position,Quaternion.identity);
            ms.Add(mdm);
        }
        yield return new WaitForSeconds(5.0f);
        foreach(GameObject g in ms){
            Destroy(g);
        }
        StartCoroutine(LaserBlow());
    }



}
