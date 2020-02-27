using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TRdie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManagerScript.lvl = "Lvl1";
        PlayerPrefs.SetString("SaveLvl", GameManagerScript.lvl);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) SceneManager.LoadScene("Lvl1");
    }
}
