using UnityEngine;
using System.Collections;

public class Bullet : CommonBullet
{

    protected override void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        HarryControl player = collider.GetComponent<HarryControl>();

        if (unit && unit != player)
        {
            Destroy(gameObject);
        }
    }
}
