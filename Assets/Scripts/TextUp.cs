using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUp : MonoBehaviour
{
    public float life, speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, speed, 0);

        Destroy(this.gameObject, life);
    }
}
