using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    public static int points = 0;
    public static string lvl = "Lvl1";

    AudioSource mainAudio;
    private GameObject[] tomas;

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

        mainAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        tomas = GameObject.FindGameObjectsWithTag("Tom");
        if (tomas.Length == 1 && !mainAudio.mute) mainAudio.mute = true;
    }



}
