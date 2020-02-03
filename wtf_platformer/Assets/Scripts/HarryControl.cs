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
    private int isWalk = 0;


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

    public static int ruby;
    public GameObject RubyObject;
    Text textRuby;
    public GameObject DialogH;
    public GameObject Zastav;

    public AudioClip coin;
    public AudioClip deathAudio;
    public AudioClip heartAudio;

    public int directionInput;
    public GameObject MobilMove;

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
        ruby = GameManagerScript.points;
        textRuby.text = ruby.ToString();
    }

    private void FixedUpdate()
    {
        if (!DialogH.activeInHierarchy && !Zastav.activeInHierarchy) Run();

    }

    private void Update()
    {
        CheckGround();
        if (isGrounded) State = CharState.harry_idel;
        if ((Input.GetButton("Horizontal") || directionInput != 0) && isGrounded && !DialogH.activeInHierarchy && !Zastav.activeInHierarchy) State = CharState.harry_run;
        if (Input.GetButton("Horizontal")) isWalk = 1;
        else isWalk = 0;

        if (Input.GetButtonDown("Fire1") && !MobilMove.activeInHierarchy) Shoot(true);
        if (harryDie && Lives < 1) Die();
        if (Input.GetButtonDown("Jump")) Jump(true);
    }


    private void Run()
    {
        if (MobilMove.activeInHierarchy) rb.velocity = new Vector2(Mathf.Lerp(0, directionInput * speed, 0.8f), rb.velocity.y - (fallspeed * Time.deltaTime));
        else rb.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed, 0.8f) * isWalk, rb.velocity.y - (fallspeed * Time.deltaTime));

        if (Input.GetKey("a") || Input.GetKey("left") || directionInput < 0) horizontal = -1;
        else if (Input.GetKey("d") || Input.GetKey("right") || directionInput > 0) horizontal = 1; 

        sprite.flipX = horizontal == -1;
    }

    public void Jump(bool isJump)
    {
        if (isGrounded && isJump && !DialogH.activeInHierarchy && !Zastav.activeInHierarchy)
        {
            rb.velocity = new Vector2(0, jumpForse);
        }
    }

    public void Move(int InputAxis)
    {
        directionInput = InputAxis;
    }

    public void Shoot(bool isShoot)
    {
        if (isShoot && !DialogH.activeInHierarchy && !Zastav.activeInHierarchy)

        {
            Vector3 position = transform.position;
            if (horizontal == 1) position.x += 0.8f;
            else position.x -= 0.8f;

            Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
            newBullet.Direction = newBullet.transform.right * horizontal;
        }
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
        //GetComponent<AudioSource>().PlayOneShot(deathAudio);
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
            Cam.transform.position = new Vector3(transform.position.x + 3f, 0.2f, -10f);
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 0.7f), 0.15f);

        isGrounded = colliders.Length > 1;


        if (!isGrounded && rb.velocity.y > 0f)
        {
            State = CharState.harry_jump;
            rb.drag = 0;
        }

        if (!isGrounded && rb.velocity.y <= 0f)
        {
            State = CharState.harry_jump_down;
            rb.drag = 0;
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
            GetComponent<AudioSource>().PlayOneShot(coin);
            textRuby.text = ruby.ToString();
            Destroy(collider.gameObject);
            Debug.Log("Ruby = " + ruby);
        }

        if (collider.tag == "Heart")
        {
            Lives++;
            GetComponent<AudioSource>().PlayOneShot(heartAudio);
            Destroy(collider.gameObject);
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



