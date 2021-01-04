using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerCamera : MonoBehaviour
{
    [SerializeField] float speed;

    //camera is created from a "platform" centric camera movement system (like in super mario world)

    //whenever a platform is detected, the camera will lineraly interpolate to that platform's location

    public void MoveCameraToPos(Transform t){
        Vector3 pos = new Vector3(transform.position.x, t.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, speed);
    }

}
