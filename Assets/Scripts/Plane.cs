using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

    public float startPosition, speed, life;

    public GameObject Drop;

    bool dropOn = true;

    public float PosDrop;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.planeOn = true;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(speed, startPosition, 0);

        if(this.transform.position.x >= PosDrop && dropOn == true)
        {
            dropOn = false;
            Instantiate(Drop, new Vector3(this.transform.position.x, this.transform.position.y, 0), Drop.transform.rotation);
            print("Drop");
        }

        Destroy(this.gameObject, life);

    }
}
