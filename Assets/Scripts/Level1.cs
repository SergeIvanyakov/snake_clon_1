using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject spawnObject;
    public float timeSpawnDrop;
    public float speed;
    public int flag = 0;
    public int k;

    public List<GameObject> dropObjectList = new List<GameObject>();

    public Game Game;
    

    // Start is called before the first frame update
    void Start()
    {
        k = Game.LevelIndex;
        Invoke("Spawn", timeSpawnDrop/k);
        
    }

    void Spawn()
    {
        if (flag == 0)
        {
            GameObject drop = Instantiate<GameObject>(spawnObject);
            int x = (int)(Random.Range(-5, 5) / 1);
            drop.transform.position = new Vector3(x, 21f, 0f);
            dropObjectList.Add(drop);
            Invoke("Spawn", timeSpawnDrop/k);
            
        }
        else { dropObjectList.RemoveAt(dropObjectList.Count-1);  }
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 speedObjectDrop = new Vector3(0f, (float)-(speed + 0.01*k), 0f);

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
