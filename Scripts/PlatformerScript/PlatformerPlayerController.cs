using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlatformerPlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float horizontal;
    private Animator anim;
    private GameObject dc; //death controller
    private GameObject ac; //audio controller
    public float life;

    [SerializeField] float acceleration;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;

    //UI

    [SerializeField] GameObject timeText;
    [SerializeField] GameObject lifeText;

    //jump timers
    private PlatformerGrounded pg;
    private float jumpTimerTime;
    private float jumpTimer;
    private float groundTimerTime;
    private float groundTimer;
    private bool isGrounded;

    //attack
    private List<Transform> transforms;

    private float AttackCD;
    public float damage;
    private float savedTime;

    [SerializeField] GameObject airOneHitBox;
    [SerializeField] GameObject normalOneHitBox;
    [SerializeField] GameObject sweepOneHitBox;

    void Awake(){
        speed = 1.0f;
        life = 10.0f;
        damage = 10.0f;
        jumpTimer = 0.2f;
        groundTimer = 0.01f;
        AttackCD = 0.3f;
        transforms = new List<Transform>();
    }

    void Start(){
        sr = GetComponent<SpriteRenderer>();
        //hitboxes
        transforms.Add(airOneHitBox.GetComponent<Transform>());
        transforms.Add(normalOneHitBox.GetComponent<Transform>());
        transforms.Add(sweepOneHitBox.GetComponent<Transform>());
        //everything else
        ac = GameObject.Find("AudioController");
        dc = GameObject.Find("DeathController");
        anim = GetComponent<Animator>();
        pg = GameObject.Find("Grounded").GetComponent<PlatformerGrounded>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        savedTime += Time.deltaTime * speed;
        ShowScore();
        lifeText.GetComponent<Text>().text = ("Life Total: "+life);
        if(life<=0){
            SceneManager.LoadScene(12);
        }


        horizontal = Input.GetAxisRaw("Horizontal");

        //Gets the player to jump
        JumpTimers();
        AnimationControl();
        Attack();

        //Testing
        /*if(Input.GetKeyDown(KeyCode.G)){
            StartCoroutine("OnDeath");
        }*/

    }

    public void SaveHighScore(){
        //save the high score, or if it is the first time then have the first score as the high score
        float high = PlayerPrefs.GetFloat("High Score Platformer");
        if(high>savedTime || high==0.0f){
            PlayerPrefs.SetFloat("High Score Platformer",savedTime);
        }
    }

    void ShowScore(){
        string minute = Mathf.Floor((savedTime%3600)/60).ToString("00");
        string second = (savedTime%60).ToString("00");
        //Debug.Log("Time: "+minute+":"+second);
        timeText.GetComponent<Text>().text = ("Time: "+minute+":"+second);
    }

    void FixedUpdate(){
        Movement();
    }

    //once the player gets hit by an enemy, they lose a life
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag.Equals("Enemy")){
            StartCoroutine(OnDeath());
        }
    }

    IEnumerator OnDeath(){
        //player gets hit once and dies
        life-=1;
        anim.SetBool("PlayerDeath", true);
        yield return new WaitForSeconds(0.25f);
        dc.GetComponent<PlatformerDeathController>().Death("player");
        yield return null;
    }

    //probably not optimal, but it references from the death controller
    public void PlayerDeathBoolFalse(){
        anim.SetBool("PlayerDeath", false);
    }

    void Movement(){
        float x = rb.velocity.x;
        if(horizontal==0)
            x = horizontal;
        else
            x += horizontal/5;
        x *= Mathf.Pow(acceleration, Time.deltaTime);
        rb.velocity = new Vector2(x, rb.velocity.y);
        //Debug.Log(rb.velocity);
    }

    void AnimationControl(){
        //if the character looks right, the hotboxes and the character will flip to the right, 
        //if else the character will turn left with the hitboxes
        if(rb.velocity.x>0){
            sr.flipX = false;
            foreach(Transform t in transforms){
                t.localEulerAngles = new Vector3(0.0f,0.0f,0.0f);
            }
        } else if(rb.velocity.x<0){
            sr.flipX = true;
            foreach(Transform t in transforms){
                t.localEulerAngles = new Vector3(0.0f,180.0f,0.0f);
            }
        }
        anim.SetFloat("Jumping",rb.velocity.y);
        //the character can only have a max velocity of 3 ?/s
        anim.SetFloat("Running",Mathf.Clamp(Mathf.Abs(rb.velocity.x),0.0f,3.0f));

        //when the character is not doing anything it will start a timer to sheave the weapon, then it will end when the character moves
        //as well as whenever any key is pressed
        if(anim.GetFloat("Jumping")==0&&anim.GetFloat("Running")==0&&!(Input.anyKey)){
            StartCoroutine("SheaveStanding");
        } else {
            anim.SetBool("SheaveTime", false);
            StopCoroutine("SheaveStanding");
        }
    }

    void Attack(){
        // a normal attack for ground and air/ as well as a sweep attack for running
        if(Input.GetKeyDown(KeyCode.Q)){
            // first check if the attack is needed when there is a y or x velocity, then it checks if that ability is already used 

            // air attack, only checks if y velocity is positive
            // normal attack, checks if x and y are 0, has to check if a heavy sword attack is activated or else it will create two hitboxes
            // sweep attack, checks if y is 0 and x is positive or negative
            if(Mathf.Abs(rb.velocity.y)>0&&Mathf.Abs(rb.velocity.y)>0&&!anim.GetBool("SwordAir")){
                StartCoroutine("AirAttack");
            } else if(rb.velocity.y==0&&rb.velocity.x==0&&!anim.GetBool("SwordNormal")){
                StartCoroutine("NormalAttack");
            } else if(rb.velocity.y==0&&Mathf.Abs(rb.velocity.x)>0&&!anim.GetBool("SwordSweep")){
                StartCoroutine("SweepAttack");
            }
            //ground heavy attack checks if x and y are 0
            // has to check if any normal sword attack is activated or else it will create two hitboxes
        }
    }

    void JumpTimers(){
        jumpTimerTime -= Time.deltaTime;
        groundTimerTime -= Time.deltaTime;

        //Grounded timer to make the character jump in the air based on time detection, a safety jump net to make controls more responsive "coyote time"
        if(pg.grounded){
            groundTimerTime = groundTimer;
        } //unsure if they worked out

        //Jump buffering, chracter has smooth movement
        if(Input.GetKeyDown(KeyCode.Space)){
            jumpTimerTime = jumpTimer;
        }

        if((jumpTimerTime > 0.0f)&&(groundTimerTime > 0.0f)){
            Jump();
        }
    }

    void Jump(){
        groundTimerTime = 0.0f;
        jumpTimerTime = 0.0f;
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }

    //coroutine made for attacks
    //also I just recently read the last feedback for the coroutine and looping thing, I figured as much, because in this game it feels 
    //very clunky to operate
    //added in the sweeping soundfx individually because of the choppy feeling
    //hard to find a way to get a "hard" hit in? Maybe have to dump that idea
    IEnumerator AirAttack(){
        anim.SetBool("SwordAir",true);
        airOneHitBox.SetActive(true);
        ac.GetComponent<PlatformerSoundController>().SwingClip();
        yield return new WaitForSeconds(AttackCD);
        airOneHitBox.SetActive(false);
        anim.SetBool("SwordAir",false);
    }

    IEnumerator NormalAttack(){
        anim.SetBool("SwordNormal",true);
        normalOneHitBox.SetActive(true);
        ac.GetComponent<PlatformerSoundController>().SwingClip();
        yield return new WaitForSeconds(AttackCD);
        normalOneHitBox.SetActive(false);
        anim.SetBool("SwordNormal",false);
    }

    IEnumerator SweepAttack(){
        anim.SetBool("SwordSweep",true);
        sweepOneHitBox.SetActive(true);
        ac.GetComponent<PlatformerSoundController>().SwingClip();
        yield return new WaitForSeconds(AttackCD);
        sweepOneHitBox.SetActive(false);
        anim.SetBool("SwordSweep",false);
    }

    IEnumerator SheaveStanding(){
        // in 5 seconds the player will automatically sheave
        yield return new WaitForSeconds(5.0f); 
        anim.SetBool("SheaveTime", true);
        yield return new WaitForSeconds(0.5f); 
        anim.SetBool("SheaveTime", false);
        StopCoroutine("SheaveStanding");
    }
}
