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
        if (transform.position.x < player.transform.position.x) toLeft = -1;
        else if (transform.position.x > player.transform.position.x) toLeft = 1;

        if (Mathf.Abs(transform.position.x - player.transform.position.x) < seeDistance && ((direction == -1f && toLeft == 1) || (direction == 1f && toLeft == -1)) && Mathf.Abs(transform.position.y - player.transform.position.y) < 2.1f)
        {
            rb.velocity = new Vector2(speedfoarse * direction * delta, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
            delta = 1f;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        if (collider.gameObject.tag == "Wall") 
        { 
            direction *= -1f;
            Flip(); 
        }

        HarryControl harry = collider.GetComponent<HarryControl>();
        if (harry)
        {
            delta = -1f;
        }
    }


}

