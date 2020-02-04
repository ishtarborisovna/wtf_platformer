using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    public static int points = 0;
    public static int isComp = 0;
    public GameObject MobilMove;
    public GameObject PlatformWindow;
    public GameObject Zastavka;

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
        if (isComp == 1 && MobilMove.activeInHierarchy) MobilMove.SetActive(false);
        else if (isComp == 2 && !MobilMove.activeInHierarchy) MobilMove.SetActive(true);

        if (isComp > 0 && PlatformWindow.activeInHierarchy)
        {
            Zastavka.SetActive(true);
            PlatformWindow.SetActive(false);
        }
    }

    public void Platform(int comp)
    {
        isComp = comp;
        Debug.Log(isComp);
    }
}
