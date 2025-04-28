using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 700f;
    public bool doubleJump = false;
    public float maxJumpTime = 0.25f;

    bool facingRight = true;
    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public float Score { get; private set; }
    public float SumScore { get; private set; }

    public float move;
    private bool key = false;
    private bool win = false;
    private Animator anim;

    private float timer = 1;
    public static Vector3 vectorPosition;
    public static bool playerDead;

    public Transform player;
    public bool checkpoint = false;

    /// <summary>
    /// Начальная инициализация
    /// </summary>
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        if (!grounded)
            return;
    }

    void Update()
    {
        Time.timeScale = timer;
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            Invoke("Respawn", 0.8f);
        }
        Jump();

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }
    }

    private void Jump()
    {
        if ((grounded || !doubleJump) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (grounded)
            {
                grounded = false;
                doubleJump = false;
            }
            else
            {
                doubleJump = true;
            }
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, jumpForce));
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Respawn()
    {
        if (checkpoint)
        {
            StartCoroutine("NewLevel", vectorPosition);
            anim.Play("GoblinIdle");
        }
        else
        {
            Restart();
        }
    }

    IEnumerator NewLevel(Vector3 pos)
    {
        yield return new WaitForSeconds(1);
        gameObject.transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            anim.Play("Die");
            Invoke("Respawn", 0.8f);
        }
        else if (col.gameObject.name == "Coins")
        {
            ++Score;
            ++SumScore;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.name == "checkpoint")
        {
            vectorPosition = col.transform.position;
            checkpoint = true;
        }
        else if (col.gameObject.name == "key")
        {
            key = true;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.name == "door" && key)
        {
            if (Application.loadedLevel == 0)
            {
                Application.LoadLevel("level2");
            }
            else if (Application.loadedLevel == 1)
            {
                Application.LoadLevel("level3");
            }
            else if (Application.loadedLevel == 2)
            {
                Application.LoadLevel("level4");
            }
            else if (Application.loadedLevel == 3)
            {
                Application.LoadLevel("level5");
            }
            else
            {
                timer = 0;
                win = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            anim.Play("Die");
            Invoke("Respawn", 0.8f);
        }
    }

    void Restart() => Application.LoadLevel(Application.loadedLevel);

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 100), "Coins: " + Score);
        if (win)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 200, 250), "Вы прошли игру!");
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 25), "Меню"))
            {
                Application.LoadLevel("Menu");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 25), "Выход"))
            {
                Application.Quit();
            }
        }
    }
}