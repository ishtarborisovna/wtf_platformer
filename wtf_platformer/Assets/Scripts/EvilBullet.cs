using UnityEngine;
using System.Collections;

public class EvilBullet : CommonBullet
{

    protected override void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
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
