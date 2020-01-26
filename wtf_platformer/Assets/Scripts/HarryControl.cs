using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarryControl : Unit
{
    [SerializeField]
    public float speed = 20f;
    [SerializeField]
    public float fallspeed = 3f;
    private Rigidbody2D rb;
    [SerializeField]
    public int lives = 5;
    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 6) lives = value;
            livesBar.Refresh();
            Debug.Log("Lives = " + lives);
        }
    }
    public LivesBar livesBar;
    [SerializeField]
    private float jumpForse = 0.01f;
    private bool isGrounded = false;
    private Animator animator;
    private SpriteRenderer sprite;

    private float horizontal = 1;



    [SerializeField]
    private Bullet bullet;
    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    public static Vector3 playerPosition;
    public GameObject Cam;
    private bool delay;
    private bool delayOrd;
    private bool harryDie;

    public int ruby;
    public GameObject RubyObject;
    Text textRuby;
    public GameObject DialogH;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        livesBar = FindObjectOfType<LivesBar>();
        textRuby = RubyObject.GetComponent<Text>();
    }

    private void Start()
    {
        livesBar.Refresh();
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
        if (Input.GetButtonDown("Fire1") && !DialogH.activeInHierarchy) Shoot();
        if (harryDie && Lives < 1) Die();
    }


    private void Run()
    {
        rb.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed, 0.8f), rb.velocity.y - (fallspeed * Time.deltaTime));
        
        if (Input.GetKey("a") || Input.GetKey("left")) horizontal = -1;
        else if (Input.GetKey("d") || Input.GetKey("right")) horizontal = 1; 

        sprite.flipX = horizontal == -1;
    }

    private void Shoot()
    {
        
        Vector3 position = transform.position;
        if (horizontal == 1) position.x += 0.8f;
        else position.x -= 0.8f;

        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        newBullet.Direction = newBullet.transform.right * horizontal;
    }

    public override void ReceiveDamage()
    {
        Lives--;

        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);

        livesBar.Refresh();
        if (Lives < 1)
        {
            harryDie = true;
            delayOrd = true;
        }
    }

    public override void Die()
    {
        Time.timeScale = 0.1f;
        if (delayOrd)
        {
            delayOrd = false;
            StartCoroutine(DelayTime(0.1f));
        }
        if (delay)
        {
            delay = false;
            harryDie = false;
            Lives = 3;
            transform.position = playerPosition;
            Cam.transform.position = new Vector3(transform.position.x + 5f, 0.2f, -10f);
            Time.timeScale = 1f;
        }
        
    }

    IEnumerator DelayTime(float sec)
    {
        Debug.Log("DelayTime " + Time.time.ToString() + "s");
        yield return new WaitForSeconds(sec);
        
        delay = true;
        Debug.Log("DelayTime end " + Time.time.ToString() + "s");
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 0.7f), 0.1f);

        isGrounded = colliders.Length > 1;

        if (!isGrounded)
        {
            rb.drag = 0;
        }

        if (!isGrounded && rb.velocity.y > 0f)
        {
            State = CharState.harry_jump;
        }

        if (!isGrounded && rb.velocity.y < 0f)
        {
            State = CharState.harry_jump_down;
        }

        if (isGrounded) rb.drag = 10;

    }


    private void OnTriggerEnter2D(Collider2D collider)
    {

        EvilBullet evilbullet = collider.gameObject.GetComponent<EvilBullet>();
        if (evilbullet)
        {
            ReceiveDamage();
        }

        if (collider.tag == "Die" && Lives > 0)
        {
            Lives = 0;
            harryDie = true;
            delayOrd = true;
        }

        if (collider.tag == "Ruby")
        {
            ruby++;
            textRuby.text = ruby.ToString();
            Destroy(collider.gameObject);
            Debug.Log("Ruby = " + ruby);
        }

    }


}


public enum CharState
{
    harry_idel,
    harry_run,
    harry_jump,
    harry_jump_down
}



