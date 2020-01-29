using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zastavka : MonoBehaviour
{
    public GameObject Zastav;
    private float rate = 5F;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Zastav.activeInHierarchy)
        {
            rate = 0.1f;
        }
        rate -= Time.deltaTime;
        if (rate <= 0) Zastav.SetActive(false);
    }
}
