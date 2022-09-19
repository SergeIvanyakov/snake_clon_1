using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private Vector3 _nachalnoePolojenieMouse;
    public Transform Head;
    public float Sensor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _nachalnoePolojenieMouse;
            
            if (Head.position.x >= 5)
            {
                delta = new Vector3(0,0,0);
                Head.position = new Vector3(4.99f, 0, 0);
                _nachalnoePolojenieMouse = new Vector3(5, 0, 0);
            }
            if (Head.position.x <= -5)
            {
                delta = new Vector3(0, 0, 0);
                Head.position = new Vector3(-4.99f, 0, 0);
                _nachalnoePolojenieMouse = new Vector3(-5, 0, 0);
            }
            
            Head.position += new Vector3(delta.x * Sensor, 0, 0);
        }
        _nachalnoePolojenieMouse = Input.mousePosition;
    }
}
