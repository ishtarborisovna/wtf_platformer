using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Diadem : MonoBehaviour
{
    [SerializeField]
    PlayableDirector director;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            director.Play();
            Destroy(gameObject);
        }
    }
}
