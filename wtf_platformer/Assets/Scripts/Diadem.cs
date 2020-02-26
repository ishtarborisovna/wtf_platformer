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
            GameManagerScript.lvl = "Lvl6";
            PlayerPrefs.SetString("SaveLvl", GameManagerScript.lvl);
            PlayerPrefs.SetInt("SavePoints", GameManagerScript.points);
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
