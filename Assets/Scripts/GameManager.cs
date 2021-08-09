using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static GameManager instance;
    [HideInInspector]
    public float gameSpeed = 1; 
    

    public int totalLives, totalPoints, totalTime;


    public Text Points, GameTime, Ammo, Score, Speed;
    public int totalAmmo;
    public float timeLoop;
    float timer;

    [HideInInspector]
    public bool planeOn = false;

    public GameObject [] vidasIcon;
    public GameObject Plane, GoArrow, NoAmmo, Player;

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
    }


    // Start is called before the first frame update
    void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Ammo.text = "AMMO: " + totalAmmo;
            Points.text = "POINTS: " + totalPoints;

            totalLives = 6;

            timer = Time.timeSinceLevelLoad;

            gameSpeed = 1;
            Speed.text = "SPEED X " + gameSpeed;

            totalPoints = 0;
            print("Game");
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameManagerStatic.instance.dataLoad();
            print("End");
            Points.text = "POINTS: " + totalPoints;
            GameTime.text = "TIME: " + totalTime;
            Score.text = "SCORE: " + totalPoints * totalTime;
        }

        if (Points != null)
        {
            Points.text = "POINTS: " + totalPoints;
        }

    }

    // Update is called once per frame
    void Update()
    {

        //incremento de la velocidad con respecto al tiempo
        if (Time.timeSinceLevelLoad >= timer + timeLoop && gameSpeed <= 2.5f)
        {
            gameSpeed = gameSpeed + 0.5f;
            Instantiate(GoArrow, new Vector3(0, 4, -0.1f), GoArrow.transform.rotation);

            print("Speed x " + gameSpeed);
            Speed.text = "SPEED X " + gameSpeed;
            timer = Time.timeSinceLevelLoad;
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameTime.text = "TIME: " + Mathf.Round(Time.timeSinceLevelLoad);
        }

        if (totalAmmo == 0 && planeOn == false)
        {

            Instantiate(NoAmmo, new Vector3(Player.transform.position.x, Player.transform.position.y, -0.15f), NoAmmo.transform.rotation);

            print ("Plane drop started");
            Instantiate(Plane, new Vector3(-30, 4, 0), Plane.transform.rotation);
        }

    }


    public void AddLifes(int LivesToAdd)
    {
        if(totalLives <= 6 || LivesToAdd <= 0 )
        {
            totalLives += LivesToAdd;

            for (int i = 0; i < vidasIcon.Length; i++)
            {
                 vidasIcon[i].SetActive(false);
            }

            for (int i = 0; i < totalLives; i++)
            {
                vidasIcon[i].SetActive(true);
            }

            if (totalLives <= 0)
            {
                Death();
            }
        }
    }

    public void Death()
    {
        GameManagerStatic.instance.StaticPoints = totalPoints;
        GameManagerStatic.instance.StaticTime = Mathf.Round(Time.timeSinceLevelLoad);

        SceneManager.LoadScene(2);
    }

    public void pointsUp()
    {
        totalPoints++;
        Points.text = "POINTS: " + totalPoints;
    }

    public void AddAmmo(int AmmoToAdd)
    {
        if(totalAmmo + AmmoToAdd < 20)
        {
            totalAmmo += AmmoToAdd;
            Ammo.text = "AMMO: " + totalAmmo;
        }
        else
        {
            totalAmmo = 20;
            Ammo.text = "AMMO: " + totalAmmo + "MAX";
        }
    }

}
