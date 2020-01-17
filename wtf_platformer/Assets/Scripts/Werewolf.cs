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

    private float deltaharry;

    private Vector3 deltaVec;

    protected override void Update()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < seeDistance)
        {
            
            FlipUpdate();

            deltaVec = new Vector3(player.transform.position.x - transform.position.x, 0, 0);
            deltaVec.Normalize();

            transform.position = transform.position + (deltaVec * delta * speedfoarse * Time.deltaTime);

            //if (toLeft < 0) deltaharry = 1f;
            //else if (toLeft > 0) deltaharry = -1f;
            //rb.velocity = new Vector2(speedfoarse * deltaharry * direction * delta, rb.velocity.y);
        }
        else if (Mathf.Abs(transform.position.x - player.transform.position.x) > seeDistance)
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
            //rb.isKinematic = false;
        }
    }


}

