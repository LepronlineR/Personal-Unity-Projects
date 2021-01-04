using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
662007329
Zhi Zheng
*/

public class AdventureEnemyScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameController;
    public GameObject EP;
    private int SpawnTimer = 0;
    private int EnemyCount = 2;
    private int IncreasingDifficulty = 0;

    // Update is called once per frame
    void Update(){
        TimeSpawn();
    }
    void TimeSpawn(){
        //Time to spawn in the enemies
        //Debug.Log(SpawnTimer);
        if((int) Time.time == SpawnTimer){
            SpawnEnemy();
            SpawnTimer = (int) Time.time + 10;
        }
    }
    void SpawnEnemy(){
        //Spawn the enemies when the enemy count is larger than a certain amount
        IncreasingDifficulty++;
        if(EnemyCount >= IncreasingDifficulty){
            GameObject EnemyPrefab = Instantiate(EP) as GameObject;
            EnemyPrefab.GetComponent<AdventureEnemyPrefabScript>();
            EnemyPrefab.transform.position = new Vector2(Random.Range(10,-10),Random.Range(10,-10));
        }
    }
}
