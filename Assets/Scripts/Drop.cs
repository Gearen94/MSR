using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    int random;
    Vector3 target;

    public Vector3 posTop;
    public Vector3 posCenter;
    public Vector3 posBottom;

    public float speed, scrollSpeed = 0.02f;

    public Animator animatorControlerParachute;

    //public float dropedTime;

    // Start is called before the first frame update
    void Start()
    {
        animatorControlerParachute.SetBool("TouchDown", false);

        random = Random.Range(0, 30);

        if (random <= 10)
        {
            target = posTop;
        }

        else if (random <= 20)
        {
            target = posBottom;
        }

        else
        {
            target = posCenter;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y == target.y)
        {
            animatorControlerParachute.SetBool("TouchDown", true);

            this.transform.position += new Vector3(-scrollSpeed * GameManager.instance.gameSpeed, 0, 0);
        }

        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        }

        if(this.transform.position.x <= -11)
        {
            print("DropLost");

            GameManager.instance.planeOn = false;
            Destroy(this.gameObject);
        }

    }

}
