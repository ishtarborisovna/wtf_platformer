using UnityEngine;
using System.Collections;

public class LivesBar : MonoBehaviour
{
    private Transform[] hearts = new Transform[5];

    private HarryControl harry;


    private void Awake()
    {
        harry = FindObjectOfType<HarryControl>();

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < harry.Lives) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
        }
    }
}
