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
        AddCircle();
        AddCircle();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = ((Vector3)SnakeHead.position - positions[0]).magnitude;
        if(distance > CircleDiametr)
        {
            positions.Insert(0, SnakeHead.position);
            positions.RemoveAt(positions.Count - 1);
            distance -= CircleDiametr;
        }

        for (int i=0; i<snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiametr);
        }
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(SnakeTail, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }
}
