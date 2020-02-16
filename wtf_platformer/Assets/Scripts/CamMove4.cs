using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove4 : MonoBehaviour
{
    public GameObject Harry;
    private float minX = 1.59f;
    private float maxX = 9.22f;
    private float camX;

    //private void Start()
    //{
    //    transform.position = new Vector3(1.59f, -0,7f, -10f);
    //}
    void Update()
    {
        if (Harry.transform.position.x > minX && Harry.transform.position.x < maxX) camX = Harry.transform.position.x;
        else if (Harry.transform.position.x < minX) camX = minX;
        else if (Harry.transform.position.x > maxX) camX = maxX;

        transform.position = new Vector3(camX, Harry.transform.position.y + 2.14f, -10f);
        
    }
}
