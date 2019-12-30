using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject Harry;
    public GameObject BackWall;

    // Update is called once per frame
    void Update()
    {
        if (Harry.transform.position.x + 5f > transform.position.x)
        {
            transform.position = new Vector3(Harry.transform.position.x + 5f, 0.2f, -10f);
            BackWall.transform.position = new Vector3(transform.position.x - 9.2f, 0, 0);
        }

    }
}
