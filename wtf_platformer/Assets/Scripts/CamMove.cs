using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject Harry;
    //public GameObject Horcrux;

    
    void Update()
    {
        //if (Harry.transform.position.x + 3f > transform.position.x && transform.position.x <= Horcrux.transform.position.x)
        if (Harry.transform.position.x >= -1.41f && Harry.transform.position.x <= 393.83f)
        {
            transform.position = new Vector3(Harry.transform.position.x + 3f, 0.2f, -10f);
        }
    }
}
