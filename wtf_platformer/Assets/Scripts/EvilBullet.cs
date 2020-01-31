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
        GetComponent<AudioSource>().PlayOneShot(spell);
        Destroy(gameObject, 1F);
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
