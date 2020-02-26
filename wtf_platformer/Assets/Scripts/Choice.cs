using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    public GameObject Harry;
    private bool choising = false;
    public GameObject ToTom;
    public GameObject ToFight;

    private void Update()
    {
        if (!choising) Harry.GetComponent<HarryControl>().enabled = false;
    }
    public void Chois(int isChois)
    {
        if (isChois == 1) 
        {
            choising = true;
            Harry.GetComponent<HarryControl>().enabled = true;
            ToTom.SetActive(true);
            Destroy(gameObject);
        }
        if (isChois == 2) 
        {
            choising = true;
            Harry.GetComponent<HarryControl>().enabled = true;
            ToFight.SetActive(true);
            Destroy(gameObject);
        }
    }
}
