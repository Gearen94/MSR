using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed, fireRate;

    public GameObject bullet, cannon;

    //Sounds
    public GameObject PistolSound, Drop, DropOK;

    //DOPS Text
    public GameObject HalfHeart, OneHeart, MinusHeart, FiveAmmo, TenAmmo;

    float nextFire = 0;

    Vector3 target;

    public Transform posTop;
    public Transform posCenter;
    public Transform posBottom;

    public Animator animatorControlerLegs;
    public Animator animatorControlerBody;

    public Animation animationHit;


    bool onTop = false;
    bool onCenter = false;
    bool onBottom = true;



    // Start is called before the first frame update
    void Start()
    {
        target = posBottom.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Vector3.Distance(this.transform.position, target) <= 0.05f)
        {
            animatorControlerLegs.SetBool("Jumping", false);
        }

        if (Time.time > nextFire)
        {
            animatorControlerBody.SetBool("Shooting", false);
        }
    }

    public void Movement()
    {

        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (onCenter == true)
            {
                target = posTop.position;
                onCenter = false;
                onTop = true;
            }

            else if (onBottom == true)
            {
                target = posCenter.position;
                onBottom = false;
                onCenter = true;
            }

            AnimationJump();

        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (onCenter == true)
            {
                target = posBottom.position;
                onCenter = false;
                onBottom = true;
            }

            else if (onTop == true)
            {
                target = posCenter.position;
                onTop = false;
                onCenter = true;
            }

            AnimationJump();
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire && GameManager.instance.totalAmmo != 0)
        {
            animatorControlerBody.SetBool("Shooting", true);
            Instantiate(PistolSound, new Vector3(cannon.transform.position.x, cannon.transform.position.y, 0), PistolSound.transform.rotation);
            Instantiate(bullet, new Vector3(cannon.transform.position.x, cannon.transform.position.y, 0), bullet.transform.rotation);

            GameManager.instance.AddAmmo(-1);

            nextFire = Time.time + fireRate;
        }
    }

    void AnimationJump()
    {
        animatorControlerLegs.SetBool("Jumping", true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knife" || collision.gameObject.tag == "Crate")
        {
            animationHit.Play();
            print("-1 heart");
            GameManager.instance.AddLifes(-2);
            Instantiate(MinusHeart, new Vector3(this.transform.position.x, this.transform.position.y, -0.15f), MinusHeart.transform.rotation);
        }

        if (collision.gameObject.tag == "AmmoDrop")
        {
            GameManager.instance.AddAmmo(+5);
            Instantiate(Drop, new Vector3(this.transform.position.x, this.transform.position.y, 0), Drop.transform.rotation);

            Instantiate(FiveAmmo, new Vector3(this.transform.position.x, this.transform.position.y, -0.15f), FiveAmmo.transform.rotation);

            print("+5 ammo");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "HealthDrop")
        {
            collision.GetComponent<Health>().animatorControlerHealt.SetBool("HealthOpen", true);
            GameManager.instance.AddLifes(1);
            Instantiate(Drop, new Vector3(this.transform.position.x, this.transform.position.y, 0), Drop.transform.rotation);

            Instantiate(HalfHeart, new Vector3(this.transform.position.x, this.transform.position.y, -0.15f), HalfHeart.transform.rotation);

            print("+1/2 heart");
        }

        if (collision.gameObject.tag == "SupplyDrop")
        {
            GameManager.instance.AddAmmo(10);
            GameManager.instance.AddLifes(2);
            print("+1 heart and +10 ammo");
            Instantiate(DropOK, new Vector3(this.transform.position.x, this.transform.position.y, 0), DropOK.transform.rotation);

            Instantiate(TenAmmo, new Vector3(this.transform.position.x, this.transform.position.y, -0.15f), TenAmmo.transform.rotation);
            Instantiate(OneHeart, new Vector3(this.transform.position.x, this.transform.position.y+1, -0.15f), OneHeart.transform.rotation);

            GameManager.instance.planeOn = false;

            print("planeOn = false");

            Destroy(collision.gameObject);
        }
    }

}
