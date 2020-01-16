using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Werewolf : Enemy
{
    [SerializeField]
    private float speed = 5.0F;
    [SerializeField]
    private float speedfoarse = 10.0F;
    [SerializeField]
    private float seeDistance = 8f;

    private float direction = -1f;

    private float delta;


    protected override void Update()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 0.7f) { }

        else if (Mathf.Abs(transform.position.x - player.transform.position.x) < seeDistance && Mathf.Abs(transform.position.x - player.transform.position.x) > 0.7f)
        {
            FlipUpdate();
            if (toLeft > 0) delta = -1f;
            else if (toLeft < 0) delta = 1f;
            transform.position = new Vector3(transform.position.x + delta * speedfoarse * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else 
        {
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
            if (direction == -1) transform.localScale = new Vector3(1, 1, 1);
            else transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        if (collider.gameObject.tag == "Wall") { direction *= -1f; }
    }


}

