using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeTall : MonoBehaviour
{
    //public Transform SnakeHead;
    //public Transform SnakeTail;
    public GameObject SnakeHead;
    public GameObject SnakeTail;
    public float CircleDiametr;
    public int fl;

    private List<GameObject> snakeCircles = new List<GameObject>();
    private List<Vector3> positions = new List<Vector3>();

    public Material d1;
    public Material d2;
    public Material d3;
    public Material d4;
    public Material d5;
    public Material h1;
    public Material h2;
    public Material h3;

    public AudioSource audio1;
    public AudioSource audio2;

    public ParticleSystem PS1;
    public ParticleSystem PS2;

    public Level1 Level;

    public Game Game;

    public Text Text1;

    public int health = 0;

    // Start is called before the first frame update
    void Start()
    {
        positions.Add(SnakeHead.transform.position);
        snakeCircles.Add(SnakeHead);
        
 
    }

    // Update is called once per frame
    void Update()
    {
       
        for (int i = 0; i < positions.Count-1; i++)
        {
            snakeCircles[i+1].transform.position = new Vector3(snakeCircles[i].transform.position.x, snakeCircles[i+1].transform.position.y, 0);
 
        }
        Text1.text = "Length " + positions.Count.ToString() + " < 10";
        //Debug.Log(positions.Count);
   
    }

    public void AddCircle()
    {
        Vector3 delta = new Vector3(0, -1, 0);
        Vector3 head = positions[positions.Count - 1];
        GameObject circle = Instantiate(SnakeTail, head + delta, Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.transform.position);
     }

    public void RemoveCircle()
    {
                 
        Destroy(snakeCircles[snakeCircles.Count - 1]);
        snakeCircles.RemoveAt(snakeCircles.Count - 1);
        positions.RemoveAt(positions.Count - 1);
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        Material material = obj.GetComponent<Renderer>().material;
        if (material.name == "d1 (Instance)") health = -1;
        if (material.name == "d2 (Instance)") health = -2;
        if (material.name == "d3 (Instance)") health = -3;
        if (material.name == "d4 (Instance)") health = -4;
        if (material.name == "d5 (Instance)") health = -5;
        if (material.name == "h1 (Instance)") health = 1;
        if (material.name == "h2 (Instance)") health = 2;
        if (material.name == "h3 (Instance)") health = 3;

        if (health > 0)
        {
            audio1.Play();
            PS1.Play();
            for (int i = 0; i < health; i++) AddCircle();
            if (snakeCircles.Count >= 10)
            {
                Debug.Log("Win!!");
                Level.flag = 1;
                fl =1;
                Game.ReloadLevel();
            }
        }
        else
        {
            audio2.Play();
            PS2.Play();
            if (health / -1 >= snakeCircles.Count) { Debug.Log("Loss!!"); Level.flag = 1; Game.ReloadLevel(); }
            else for (int i = health; i < 0; i++) RemoveCircle();
        }
        }

    private object GetComponent<T>(GameObject obj)
    {
        throw new NotImplementedException();
    }
}
