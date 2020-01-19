using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    [SerializeField]
    private float speed = 8.0F;
    private float speeddown = 10.0F;
    private float direction = 1f;
    private bool sleeping = true;
    private float seeDistance = 2f;
    private bool isGrounded = false;

    protected override void Update()
    {
        CheckGround();
        if (sleeping && Mathf.Abs(transform.position.x - player.transform.position.x) < seeDistance)
        {
            sleeping = false;
        }
        else if (!sleeping && !isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, -1 * speeddown);
        }
        else if (isGrounded && !sleeping)
        {
            rb.velocity = new Vector2(speed * direction, 0);
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
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 0.1f), 0.3f);

        isGrounded = colliders.Length > 1;

    }

}
