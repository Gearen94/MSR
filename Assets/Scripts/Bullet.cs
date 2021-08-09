using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed, life;
    public GameObject SoundSource;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(SoundSource, new Vector3(0, 0, 0), SoundSource.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(speed, 0, 0);
        Destroy(this.gameObject, life);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
