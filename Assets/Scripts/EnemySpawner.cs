using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy, Crate;

    float fireRate = 1;

    //float range;

    float nextEnemy;
    float random;

    float targetY;

    bool onTop = false;
    bool onCenter = false;
    bool onBottom = true;
    bool crateOn = false;

    public GameObject posTop;
    public GameObject posCenter;
    public GameObject posBottom;

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, 40);
        targetY = posBottom.transform.position.y;
    }

    // Update is called once per frame

    void Update()
    {
        if(GameManager.instance.gameSpeed == 1.5f)
        {
            fireRate = 0.8f;
        }
        else if(GameManager.instance.gameSpeed == 2)
        {
            fireRate = 0.6f;
        }
        else if(GameManager.instance.gameSpeed == 2.5f)
        {
            fireRate = 0.4f;
        }
        else if (GameManager.instance.gameSpeed == 3)
        {
            fireRate = 0.2f;
        }

        Spawn();
    }

    void Spawn()
    {
        if (Time.time > nextEnemy)
        {
            random = Random.Range(0, 40);

            if (random <= 10 && onTop == false)
            {
                onTop = true;
                onCenter = false;
                onBottom = false;
                crateOn = false;

                targetY = posTop.transform.position.y;
                generate();
            }
            else if (random <= 20 && onBottom == false)
            {
                onTop = false;
                onCenter = false;
                onBottom = true;
                crateOn = false;

                targetY = posBottom.transform.position.y;
                generate();
            }
            else if (random <= 30 && onCenter == false)
            {
                onTop = false;
                onCenter = true;
                onBottom = false;
                crateOn = false;

                targetY = posCenter.transform.position.y;
                generate();
            }
            else if (crateOn == false)
            {
                crateOn = true;
                Instantiate(Crate, new Vector3(this.transform.position.x, targetY + 0.15f, 0), Crate.transform.rotation);
                nextEnemy = Time.time + fireRate;
            }
        }
    }

    void generate()
    {
        Instantiate(Enemy, new Vector3(this.transform.position.x, targetY - 0.7f, 0), Enemy.transform.rotation);
        nextEnemy = Time.time + fireRate;
    }
}
