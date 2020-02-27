using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zastavka : MonoBehaviour
{
    private float rate = 5F;
    public GameObject MainImage;
    public GameObject ManualText;

    private void Start()
    {
        GameManagerScript.lvl = PlayerPrefs.GetString("SaveLvl", "Lvl1");
        GameManagerScript.points = PlayerPrefs.GetInt("SavePoints", 0);
    }
    void Update()
    {
            
            rate -= Time.deltaTime;

            if (rate <= 0 && MainImage.activeInHierarchy)
            {
            MainImage.SetActive(false);
            ManualText.SetActive(true);
            }

            if (Input.GetButtonDown("Fire1") && ManualText.activeInHierarchy)
            {
            SceneManager.LoadScene(GameManagerScript.lvl);
        }

        }
}
