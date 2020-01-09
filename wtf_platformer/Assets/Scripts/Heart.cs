using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour
{
    private LivesBar livesBar;

    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        HarryControl harry1 = collider.GetComponent<HarryControl>();

        if (harry1)
        {
            harry1.Lives++;
            Destroy(gameObject);
        }
    }
}
