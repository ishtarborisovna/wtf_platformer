using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Diadem : MonoBehaviour
{
    [SerializeField]
    PlayableDirector director;
    public GameObject ToLvl6;

    private void Update()
    {
        if (ToLvl6.activeInHierarchy)
        {
            GameManagerScript.points = HarryControl.ruby;
            SceneManager.LoadScene("Lvl6");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            director.Play();
        }
    }
}
