using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
662007329
Zhi Zheng
*/

public class ApplePickerEnemyScript : MonoBehaviour
{
    private int minute, second;
    public int mineralCount, vespeneCount;
    private float savedTime;
    private int speed;
    public float unitSpeed;
    public GameObject TimeCounter;
    public GameObject Base;
    private bool onceMoney;

    void Start(){
        speed = 1;
        unitSpeed = 2.5f;
        mineralCount = 0;
        vespeneCount = 0;
        onceMoney = false;
        InvokeRepeating("UpdateVelocity",0.0f,20.0f);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(unitSpeed, 0.0f);
    }

    // Update is called once per frame
    void Update(){
        SavedTime();
        ChangeLocation();
        EmergencyMoney();
        PlayerPrefs.SetInt("enemy mineral",mineralCount);
        PlayerPrefs.SetInt("enemy vespene",vespeneCount);
    }
    void EmergencyMoney(){
        if(Base.GetComponent<ApplePickerUnit>().health<=300 && !onceMoney){
            mineralCount+=200;
            vespeneCount+=200;
            onceMoney = true;
        }
    }
    void UpdateVelocity(){
        unitSpeed+=0.5f;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(unitSpeed, 0.0f);
    }

    void SavedTime(){
        //add to the time component of the game, using Time.deltaTime
        savedTime += Time.deltaTime * speed;
        string minute = Mathf.Floor((savedTime%3600)/60).ToString("00");
        string second = (savedTime%60).ToString("00");
        TimeCounter.GetComponent<Text>().text = ("Time: "+minute+":"+second);
    }

    void ChangeLocation(){
        //for the enemy their position will be tested: if the enemy reaches the boundary it will go back
        if(transform.position.x > 7.0f){
           transform.position = new Vector2(6.99f, transform.position.y);
           GetComponent<Rigidbody2D>().velocity *= -1.0f;
        }
        if(transform.position.x < -7.0f){
            transform.position = new Vector2(-6.99f, transform.position.y);
            GetComponent<Rigidbody2D>().velocity *= -1.0f;
        }
    }

    /*percentages for the bot to make a decision to pick whichever unit based on the amount of minerals they have and time passed
        - (time)^2/20250  = battlecruiser (in 90 seconds the percent of building a ship increases from 0 to 40%) 
        - (time)^2/13500 = siege tanks (in 90 seconds the percent of building a tank increases from 0 to 60%)
        - the percentages caps at 90 seconds.
        - Percent of the marine is based on the difference between both the siegetanks and battlecruiser
    */
    public string EnemyBuy(){
        int r = Random.Range(0,100);
        double x = (double) Mathf.Pow(Time.time,2);
        if((int)Time.time > 90){
            x = 90;
        }
        if(r<(x/20250)*100){
            return "SiegeTank";
        }
        if(r>(x/13500)*100){
            return "Battlecruiser";
        }else{
            return "Marine";
        }
    }

    //When this object touches the mineral or vespene it will iterate to 5 and then delete the mineral/vespene object "collecting" it
    void OnTriggerEnter2D(Collider2D collsion){
        if(collsion.gameObject.tag.Equals("Mineral")){
            mineralCount+=5;
            Destroy(collsion.gameObject);
        }
        if(collsion.gameObject.tag.Equals("Vespene")){
            vespeneCount+=5;
            Destroy(collsion.gameObject);
        }
    }
}
