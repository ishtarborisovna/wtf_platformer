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
            SceneManager.LoadScene("Lvl4");
        }
    }
}
