using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public GameObject head;
    public GameObject bodyPrefab;
    public float bodySpeed = 5;
    public int gap = 10;

    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionHistory = new List<Vector3>();
    void Start()
    {
        GrowSnake();
        GrowSnake();
    }
    
    void Update()
    {
        positionHistory.Insert(0, transform.position);

        int index = 0;
        foreach(var body in bodyParts)
        {
            Vector3 point = positionHistory[Mathf.Min(index * gap, positionHistory.Count - 1)];
            Vector3 moveDiraction = point - body.transform.position;
            body.transform.position += moveDiraction * bodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }
    }
    
    public void GrowSnake()
    {
        
        GameObject body = Instantiate(bodyPrefab);
        body.GetComponent<Renderer>().material.color = head.GetComponent<Renderer>().material.color;
        bodyParts.Add(body);
    }

    public void DestroyTail(float damage)
    {
        for (int i = 0; i < damage; i++)
        {
            if (bodyParts.Count < damage)
            {
                head.GetComponent<SnakeHead>().Death();
            }

            else
            {
                Destroy(bodyParts[i]);
                bodyParts.RemoveAt(i);
                positionHistory.RemoveAt(i);
            }
            
        }
    }
}
