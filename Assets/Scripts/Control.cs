using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private Vector3 _nachalnoePolojenieMouse;
    public Transform Head;
    public int widthRoad;

    public Game sGame;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int a = (int)(widthRoad / 2);
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _nachalnoePolojenieMouse;
            
            if (Head.position.x > a)
            {
                delta = new Vector3(0,0,0);
                Head.position = new Vector3(a, 0, 0);
                _nachalnoePolojenieMouse = new Vector3(a, 0, 0);
            }
            if (Head.position.x < -a)
            {
                delta = new Vector3(0, 0, 0);
                Head.position = new Vector3(-a, 0, 0);
                _nachalnoePolojenieMouse = new Vector3(-a, 0, 0);
            }
            
            Head.position += new Vector3(delta.x * sGame.speedSensor, 0, 0);
        }
        _nachalnoePolojenieMouse = Input.mousePosition;


        

    }
}
