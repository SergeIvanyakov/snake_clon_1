using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public float speedSensor;
    public int level;
    public float timeDrop;
    public enum State
    {
        Start,
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        timeDrop = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        timeDrop = timeDrop / level;
        Debug.Log(timeDrop);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
