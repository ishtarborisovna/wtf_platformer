using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    
    private float speed;
    private float speeddown = 16.0F;
    private float direction = 1f;
    private bool sleeping = true;
    private float seeDistance = 2f;
    private bool isGrounded = false;

    private SpiderState State
    {
        get { return (SpiderState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    protected override void Start()
    {
        base.Start();
        speed = Random.Range(8.0f, 12.0f);
    }
    protected override void Update()
    {
        CheckGround();

        if (sleeping && Mathf.Abs(transform.position.x - player.transform.position.x) < seeDistance)
        {
            sleeping = false;
            State = SpiderState.spider_sleep;
        }
        else if (!sleeping && !isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, -1 * speeddown);
            State = SpiderState.spider_jump;
        }
        else if (isGrounded && !sleeping)
        {
            rb.velocity = new Vector2(speed * direction, 0);
            State = SpiderState.spider_run;
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
        if (collider.tag == "Die")
        {
            Destroy(gameObject);
        }

    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 0.1f), 0.3f);

        isGrounded = colliders.Length > 1;

    }

}

public enum SpiderState
{
    spider_sleep,
    spider_jump,
    spider_run
}
