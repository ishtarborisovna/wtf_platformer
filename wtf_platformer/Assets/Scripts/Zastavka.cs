using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zastavka : MonoBehaviour
{
    public GameObject text20;
    private float rate = 5F;
    private float rate2 = 5F;
    Text textMain;
    private int click = 0;

    private void Start()
    {
        textMain = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (GameManagerScript.isComp > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                rate = 0f;
                rate2 = 0.1f;
            }

            rate -= Time.deltaTime;
            rate2 -= Time.deltaTime;

            if (click == 0 && rate <= 0)
            {
                text20.SetActive(false);
                textMain.text = "Chapter 1".ToString();
                click = 1;
                rate2 = 5F;
            }

            if (click == 1 && rate2 <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
