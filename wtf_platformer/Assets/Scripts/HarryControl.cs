using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarryControl : MonoBehaviour
{
    [SerializeField]
    public float speed = 20f;
    private Rigidbody2D rb;
    private bool faceRight = true;

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

        //float moveX = Input.GetAxis("Horizontal");
        //rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);

        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();

        //if (moveX > 0 && !faceRight)
        //    flip();
        //else if (moveX < 0 && faceRight)
        //    flip();
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
        //это косяк
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.83f);

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



