using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter : MonoBehaviour
{
    private float rate = 5F;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rate = 0.1f;
        }

        rate -= Time.deltaTime;

        if (rate <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
