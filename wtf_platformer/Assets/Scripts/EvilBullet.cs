using UnityEngine;
using System.Collections;

public class EvilBullet : CommonBullet
{
    
    private Vector3 harryPos;
    private Vector3 delta;

    protected override void Start()
    {
        harryPos = GameObject.Find("Harry").transform.position;
        delta = harryPos - transform.position;
        delta.Normalize();

        Destroy(gameObject, 3F);
    }
    protected override void Update()
    {
        transform.position = transform.position + (delta * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        HarryControl player = collider.GetComponent<HarryControl>();

        if (player)
        {
            Destroy(gameObject);
        }
    }

}
