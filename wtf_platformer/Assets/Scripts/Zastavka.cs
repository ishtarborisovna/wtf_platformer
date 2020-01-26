using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zastavka : MonoBehaviour
{
    public GameObject Zastav;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Zastav.activeInHierarchy)
        {
            Zastav.SetActive(false);
        }
    }
}
