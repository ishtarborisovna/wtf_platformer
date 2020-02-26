using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cup : MonoBehaviour
{
    private bool active = false;
    private GameObject[] guards;


    private void Update()
    {
        guards = GameObject.FindGameObjectsWithTag("Guard");
        if (guards.Length == 0)
        {
            Move();
            active = true;
        }
    }

    private void Move()
    {
        if (transform.position.y > 79.88f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - (1 * Time.deltaTime));
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && active)
        {
            GameManagerScript.points = HarryControl.ruby;
            GameManagerScript.lvl = "Lvl5";
            PlayerPrefs.SetString("SaveLvl", GameManagerScript.lvl);
            PlayerPrefs.SetInt("SavePoints", GameManagerScript.points);
            SceneManager.LoadScene("Lvl5");
        }
    }
}
