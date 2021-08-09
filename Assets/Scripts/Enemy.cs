using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float random, timeSpawn;
    public float time, scrollSpeed;
    public GameObject AmmoDrop, HealthDrop, BloodEfect, Knife, OnePoint;
    public float destroytime;

    public Animator animatorControlerEnemy;

    private AudioSource audioSource;
    public AudioClip[] screams;
    private AudioClip screamClip;


    // Start is called before the first frame update
    void Start()
    {
        animatorControlerEnemy.SetBool("Dead", false);

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-scrollSpeed * GameManager.instance.gameSpeed, 0, 0);

        Destroy(this.gameObject, time);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(BloodEfect, new Vector3(this.transform.position.x, this.transform.position.y + 1f, 0), BloodEfect.transform.rotation);

            Instantiate(OnePoint, new Vector3(this.transform.position.x, this.transform.position.y, -0.15f), OnePoint.transform.rotation);

            //random scream
            int index = Random.Range(0, screams.Length);
            screamClip = screams[index];
            audioSource.clip = screamClip;
            audioSource.Play();

            GameManager.instance.pointsUp();
            random = Random.Range(0, 10);

            if (random >= 7  && random < 9)
            {
                Instantiate(AmmoDrop, new Vector3(this.transform.position.x, this.transform.position.y, 0), AmmoDrop.transform.rotation);
            }
            else if(random >= 9)
            {
                Instantiate(HealthDrop, new Vector3(this.transform.position.x, this.transform.position.y, 0), HealthDrop.transform.rotation);
            }

            animatorControlerEnemy.SetBool("Dead", true);

            Collider2D[] ColliderEnemy = GetComponents<Collider2D>();
            ColliderEnemy[0].enabled = false;

            Destroy(Knife.gameObject);

            Destroy(this.gameObject, destroytime);
        }
    }
}
