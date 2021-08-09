using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    float timeSpawn;
    public float time, scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-scrollSpeed * GameManager.instance.gameSpeed, 0, 0);

        Destroy(this.gameObject, time);
    }
}