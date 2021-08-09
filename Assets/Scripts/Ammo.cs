using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float endPosition, scrollSpeed;

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
            Destroy(this.gameObject);
        }
    }
}
