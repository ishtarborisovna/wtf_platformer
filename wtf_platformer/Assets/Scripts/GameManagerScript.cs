using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    public static int points = 0;
    public static string lvl = "Lvl1";

    private bool paused = false;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

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
            }
            else if (paused)
            {
                Time.timeScale = 1;
                paused = false;
            }
        }
    }

}
