using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float damage = 3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SnakeHead>())
        {
            other.GetComponent<SnakeHead>().damageAmount = damage;
            Destroy(gameObject);
        }

        
    }
}
