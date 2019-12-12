using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarryControl : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    private bool faceRight = true;

    [SerializeField]
    private int lives = 5;
    [SerializeField]
    private float jumpForse = 5.0f;

    private bool isGrounded = false;
    //private Animator animator;
    //private SpriteRenderer sprite;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);


        if (isGrounded && Input.GetButtonDown("Jump")) Jump();

        if (moveX > 0 && !faceRight)
            flip();
        else if (moveX < 0 && faceRight)
            flip();
    }

    private void flip ()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
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
    }


}
