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
    private float jumpForse = 0.01f;
    private bool isGrounded = false;
    private Animator animator;
    private SpriteRenderer sprite;

    public bool isFacingRight = true;
    public enum ProjectAxis { onlyX = 0, xAndY = 1 };
    public ProjectAxis projectAxis = ProjectAxis.onlyX;
    private float horizontal;

    private Bullet bullet;
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
        bullet = Resources.Load<Bullet>("Bullet");

    }

    private void FixedUpdate()
    {
        CheckGround();
        Run();

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(0, jumpForse);
        }

    }

    private void Update()
    {
        if (isGrounded) State = CharState.harry_idel;
        if (Input.GetButton("Horizontal") && isGrounded) State = CharState.harry_run;
        if (Input.GetButtonDown("Fire1")) Shoot();

    }

    private void Run()
    {
        rb.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed, 0.8f), rb.velocity.y);
        
        if (Input.GetKey("a") || Input.GetKey("left")) horizontal = -1;
        else if (Input.GetKey("d") || Input.GetKey("right")) horizontal = 1; else horizontal = 0;

        if (horizontal > 0 && !isFacingRight) Flip(); else if (horizontal < 0 && isFacingRight) Flip();
    }
    private void Flip()
    {
        if (projectAxis == ProjectAxis.onlyX)
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void Shoot()
    {
        Vector3 position = transform.position; 
        position.y += 0.8F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
    }

    public override void ReceiveDamage()
    {
        lives--;

        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * 15.0F, ForceMode2D.Impulse);

        Debug.Log(lives);
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 0.7f), 0.1f);

        isGrounded = colliders.Length > 1;

        if (!isGrounded)
        {
            State = CharState.harry_jump;
            rb.drag = 0;
        }

        if (isGrounded) rb.drag = 10;

    }


    private void OnTriggerEnter2D(Collider2D collider)
    {

        Bullet bullet = collider.gameObject.GetComponent<Bullet>();
        if (bullet && bullet.Parent != gameObject)
        {
            ReceiveDamage();
        }
    }

}


public enum CharState
{
    harry_idel,
    harry_run,
    harry_jump
}



