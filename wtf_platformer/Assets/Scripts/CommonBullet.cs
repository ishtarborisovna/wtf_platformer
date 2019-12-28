using UnityEngine;
using System.Collections;

public class CommonBullet : MonoBehaviour
{

    protected float speed = 10.0F;
    protected Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    protected virtual void Awake()
    {
    }

    protected virtual void Start()
    {
        Destroy(gameObject, 10F);
    }


    protected virtual void Update()
    {
    }

}
