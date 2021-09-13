using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject followingObject;
    public float distanceToObject = 10;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 
            followingObject.transform.position.z - distanceToObject);
    }
}
