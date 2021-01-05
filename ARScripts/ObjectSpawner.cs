using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectToSpawn;
    private PlacementIndicator placementIndicator;
    private int change;

    public void ChangeShape(string s){
        if(s.Equals("Cylinder")){
            change = 0;
        }
        if(s.Equals("Cube")){
            change = 1;
        }
        if(s.Equals("Sphere")){
            change = 2;
        }
    }
    void Start(){
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    void Update(){
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            GameObject obj = Instantiate(objectToSpawn[change],placementIndicator.transform.position,placementIndicator.transform.rotation);
        }
    }
}
