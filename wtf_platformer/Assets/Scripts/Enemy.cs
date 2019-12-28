using UnityEngine;
using System.Collections;

public class Enemy : Unit
{
    protected bool isFacingLeft = true;

    public HarryControl player;
    protected float toLeft;
    protected SpriteRenderer sprite;

    protected virtual void Awake() {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    protected virtual void Start() { }
    protected virtual void Update() { }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();

        if (bullet)
        {
            ReceiveDamage();
        }

        HarryControl harry = collider.GetComponent<HarryControl>();

        if (harry)
        {
            harry.ReceiveDamage();
        }
    }

    protected void Flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    protected void FlipUpdate()
    {
        if (player.transform.position.x - transform.position.x > 0.3F) toLeft = -1;
        else if (transform.position.x - player.transform.position.x > 0.3F) toLeft = 1; else toLeft = 0;

        if (toLeft < 0 && isFacingLeft) Flip();
        else if (toLeft > 0 && !isFacingLeft) Flip();
    }
}
