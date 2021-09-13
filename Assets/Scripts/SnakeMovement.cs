using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public int speed;
    public float maxOffset = 2;

    private float playerPositionX;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                playerPositionX = raycastHit.point.x;

                if (raycastHit.point.x >= maxOffset)
                {
                    playerPositionX = maxOffset;
                    Debug.Log("Попал в правый отбойник");
                }

                else if (raycastHit.point.x <= -maxOffset)
                {

                    playerPositionX = -maxOffset;
                    Debug.Log("Попал в левый отбойник");
                }
            }
        }

        else
        {
            playerPositionX = transform.position.x;
        }

        transform.position = new Vector3(playerPositionX, transform.position.y,
            transform.position.z + speed * Time.deltaTime);
    }
}
