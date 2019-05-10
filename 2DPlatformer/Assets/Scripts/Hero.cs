using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{
    //public float maxSpeed = 10f;
    //public float jumpForce = 700f;
    //bool facingRight = true;
    //public bool grounded = false;
    //public Transform groundCheck;
    //public float groundRadius = 0.2f;
    //public LayerMask whatIsGround;
    //public float Score { get; private set; }
    //public float move;
    //public bool doubleJump = false;
    //private bool key = false;

    //// Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    //    move = Input.GetAxis("Horizontal");
    //}

    //void Update()
    //{
    //    if ((grounded || !doubleJump) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
    //    {
    //        if (grounded)
    //        {
    //            grounded = false;
    //            doubleJump = false;
    //        }
    //        else
    //        {
    //            doubleJump = true;
    //        }
    //        GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, jumpForce));
    //    }
    //    GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

    //    if (move > 0 && facingRight)
    //        Flip();
    //    else if (move < 0 && !facingRight)
    //        Flip();

    //    if (Input.GetKey(KeyCode.Escape))
    //    {
    //        Application.Quit();
    //    }

    //    if (Input.GetKey(KeyCode.R))
    //    {
    //        Application.LoadLevel(Application.loadedLevel);
    //    }
    //}

    //void Flip()
    //{
    //    facingRight = !facingRight;
    //    Vector3 theScale = transform.localScale;
    //    theScale.x *= -1;
    //    transform.localScale = theScale;
    //}

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.name == "Coins")
    //    {
    //        ++Score;
    //        Destroy(col.gameObject);
    //    }
    //    else if (col.gameObject.name == "dieCollider")
    //        Application.LoadLevel(Application.loadedLevel);
    //    else if (col.gameObject.name == "key")
    //    {
    //        key = true;
    //        Destroy(col.gameObject);
    //    }
    //    else if (col.gameObject.name == "door" && key)
    //        Application.LoadLevel("level2");
    //}


    //void OnGUI()
    //{
    //    GUI.Box(new Rect(0, 0, 100, 100), "Coins: " + Score);
    //}
}