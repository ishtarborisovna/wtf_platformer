using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ring : MonoBehaviour
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
        if (transform.position.y > -2.32f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - (1 * Time.deltaTime));
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && active)
        {
            GameManagerScript.points = HarryControl.ruby;
            SceneManager.LoadScene("Lvl4");
        }
    }
}
