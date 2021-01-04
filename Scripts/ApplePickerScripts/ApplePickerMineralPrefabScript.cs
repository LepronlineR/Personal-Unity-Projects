using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
662007329
Zhi Zheng
*/

public class ApplePickerMineralPrefabScript : MonoBehaviour
{
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
