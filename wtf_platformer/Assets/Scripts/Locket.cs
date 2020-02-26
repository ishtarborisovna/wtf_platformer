using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Locket : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            GameManagerScript.points = HarryControl.ruby;
            GameManagerScript.lvl = "Lvl4";
            PlayerPrefs.SetString("SaveLvl", GameManagerScript.lvl);
            PlayerPrefs.SetInt("SavePoints", GameManagerScript.points);
            SceneManager.LoadScene("Lvl4");
        }
    }
}
