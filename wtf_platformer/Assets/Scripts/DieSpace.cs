using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpace : MonoBehaviour
{
    public GameObject respawn;
    public new GameObject camera;

    void OnTriggerEnter2D (Collider2D other)
    {

        if (other.tag == "Player")
        {
            other.transform.position = respawn.transform.position;
            camera.transform.position = new Vector3(respawn.transform.position.x + 5f, 0.2f, -10f);
        }
    }
}
