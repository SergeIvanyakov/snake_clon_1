using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public float speedSensor;
    public int level;
    public float timeDrop;
    public SnakeTall SnakeTall;

    public Text Text;
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
        timeDrop = 2f;
        Text.text = "Level " + LevelIndex.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeDrop = timeDrop / level;
        if (SnakeTall.fl == 1) { LevelIndex++; SnakeTall.fl = 0; }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int LevelIndex
    {
        get => PlayerPrefs . GetInt("LevelIndex",1);
        private set
        {
            PlayerPrefs.SetInt("LevelIndex", value);
            PlayerPrefs.Save();
        }
    }
}
