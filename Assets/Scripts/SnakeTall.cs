using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTall : MonoBehaviour
{
    public Transform SnakeHead;
    public Transform SnakeTail;
    public float CircleDiametr;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
  
    
    // Start is called before the first frame update
    void Start()
    {
        positions.Add(SnakeHead.position);
        snakeCircles.Add(SnakeHead);
        //AddCircle();

    }

    // Update is called once per frame
    void Update()
    {   
        snakeCircles[0].position = new Vector3(SnakeHead.position.x, snakeCircles[0].position.y, 0);
        for (int i = 0; i < positions.Count-1; i++)
        {
            snakeCircles[i+1].position = new Vector3(snakeCircles[i].position.x, snakeCircles[i+1].position.y, 0);
        }
        Debug.Log(positions.Count);
    }

    public void AddCircle()
    {
        Vector3 delta = new Vector3(0, -1, 0);
        Vector3 head = positions[positions.Count - 1];
        Transform circle = Instantiate(SnakeTail, head + delta, Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
     }

   
    private void OnTriggerEnter(Collider other)
    {
        AddCircle();
    }
}
