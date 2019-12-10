using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject Harry;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (Harry.transform.position.x, 0.2f, -10f);
    }
}
