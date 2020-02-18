using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove4 : MonoBehaviour
{
    public GameObject Harry;
    private float minX = 1.51f;
    private float minX1 = 1.51f;
    private float minX2 = 23.85f;
    private float minX3 = 51.2f;

    private float maxX = 9.3f;
    private float maxX1 = 9.3f;
    private float maxX2 = 31.6f;
    private float maxX3 = 58.95f;
    private float maxX4 = 89.2f;
    private float camX;

    //private void Start()
    //{
    //    transform.position = new Vector3(1.59f, -0,7f, -10f);
    //}
    void Update()
    {
        if (Harry.transform.position.y <= 25.53f) { minX = minX1; maxX = maxX1; }
        else if (Harry.transform.position.y > 25.53f && Harry.transform.position.y <= 33.56f) { minX = minX1; maxX = maxX2; }
        else if (Harry.transform.position.y > 33.56f && Harry.transform.position.y <= 45.3f) { minX = minX2; maxX = maxX2; }
        else if (Harry.transform.position.y > 45.3f && Harry.transform.position.y <= 53f) { minX = minX2; maxX = maxX3; }
        else if (Harry.transform.position.y > 53f && Harry.transform.position.y <= 75f) { minX = minX3; maxX = maxX3; }
        else if (Harry.transform.position.y > 75f) { minX = minX3; maxX = maxX4; }

        if (Harry.transform.position.x > minX && Harry.transform.position.x < maxX) camX = Harry.transform.position.x;
        else if (Harry.transform.position.x < minX) camX = minX;
        else if (Harry.transform.position.x > maxX) camX = maxX;

        transform.position = new Vector3(camX, Harry.transform.position.y + 2.14f, -10f);
        
    }
}
