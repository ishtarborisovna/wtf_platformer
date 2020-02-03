using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove3 : MonoBehaviour
{
    public GameObject Harry;

    
    void Update()
    {
        if (Harry.transform.position.x >= -1.41f && Harry.transform.position.x <= 465f)
        {
            transform.position = new Vector3(Harry.transform.position.x + 3f, 0.2f, -10f);
        }
    }
}
