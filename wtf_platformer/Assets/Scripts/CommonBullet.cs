using UnityEngine;
using System.Collections;

public class CommonBullet : MonoBehaviour
{

    protected float speed = 10.0F;
    protected Vector3 direction;
    public Vector3 Direction { set { direction = value; } }
    public AudioClip spell;

    protected virtual void Awake()
    {
    }

    protected virtual void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(spell);
        Destroy(gameObject, 1F);
    }


    protected virtual void Update()
    {
    }

}
