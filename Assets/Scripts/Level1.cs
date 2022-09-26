using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject spawnObject;
    public float timeSpawnDrop;
    public float speed;

    private List<GameObject> dropObjectList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", timeSpawnDrop);
        
    }

    void Spawn()
    {

        GameObject drop = Instantiate<GameObject>(spawnObject);
        int x = (int) (Random.Range(-5, 5) / 1);
        drop.transform.position = new Vector3(x, 21f, 0f);
        dropObjectList.Add(drop);
        Invoke("Spawn", timeSpawnDrop);

    }

    // Update is called once per frame
    void Update()
    {
        
       

        Vector3 speedObjectDrop = new Vector3(0f, -speed, 0f);

        for (int i = dropObjectList.Count - 1; i >0; i--)
        {
            dropObjectList[i].transform.position += speedObjectDrop;
        }
        for (int i = 0; i < dropObjectList.Count; i++)
        {
            if (dropObjectList[i].transform.position.y < -2) { dropObjectList.RemoveAt(i);  };
        }
    }
}
