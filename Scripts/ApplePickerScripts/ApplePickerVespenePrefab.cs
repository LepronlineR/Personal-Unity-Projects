using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
662007329
Zhi Zheng
*/

public class ApplePickerVespenePrefab : MonoBehaviour
{
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
