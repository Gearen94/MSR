using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerStatic : MonoBehaviour
{
    public static GameManagerStatic instance;
    public int StaticPoints;
    public float StaticTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(instance);
    }

    public void dataLoad()
    {
        GameManager.instance.totalPoints = StaticPoints;
        GameManager.instance.totalTime = (int)StaticTime;
    }
}
