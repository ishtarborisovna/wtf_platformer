using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaWindow : MonoBehaviour
{
    private bool paused = false;
    public GameObject PausaWin;

    private void Update()
    {
        Pausa();
    }

    private void Pausa()
    {
        if (Input.GetKeyDown("p"))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
                PausaWin.SetActive(true);
            }
            else if (paused)
            {
                Time.timeScale = 1;
                paused = false;
                PausaWin.SetActive(false);
            }
        }
    }
}
