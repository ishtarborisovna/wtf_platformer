using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zastavka : MonoBehaviour
{
    private float rate = 5F;

    private void Start()
    {
        GameManagerScript.lvl = PlayerPrefs.GetString("SaveLvl");
        GameManagerScript.points = PlayerPrefs.GetInt("SavePoints");

    }
    void Update()
    {
            if (Input.GetButtonDown("Fire1"))
            {
                rate = 0f;
            }

            rate -= Time.deltaTime;

            if (rate <= 0)
            {
                 SceneManager.LoadScene(GameManagerScript.lvl);
            }
        }
}
