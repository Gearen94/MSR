using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    public float startPosition, endPosition, scrollSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-scrollSpeed * GameManager.instance.gameSpeed, 0, 0);
      
        if (this.transform.position.x <= endPosition)
        {
            this.transform.position = new Vector3(startPosition-0.02f, this.transform.transform.position.y, this.transform.position.z);
        }

    }
}
