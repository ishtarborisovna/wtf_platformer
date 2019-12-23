using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarryControl : Unit
{
    [SerializeField]
    public float speed = 20f;
    private Rigidbody2D rb;
    [SerializeField]
    private int lives = 5;
    [SerializeField]
    private float jumpForse = 5.0f;
    private bool isGrounded = false;
    private Animator animator;
    private SpriteRenderer sprite;
    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded) State = CharState.harry_idel;

        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0f;

        if (isGrounded) State = CharState.harry_run;
    }
    private void Jump()
    {
        rb.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 0.7f), 0.2f);

        isGrounded = colliders.Length > 1;

        if (!isGrounded) State = CharState.harry_jump;
    }


}


public enum CharState
{
    harry_idel,
    harry_run,
    harry_jump
}



