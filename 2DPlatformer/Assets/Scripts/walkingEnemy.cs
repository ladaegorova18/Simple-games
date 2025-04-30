using UnityEngine;
using System.Collections;

/// <summary>
/// Simple enemies: just walk
/// </summary>
public class walkingEnemy : MonoBehaviour
{
    private float speed = 4f;
    public float direction = -1f;
    private bool facingRight = false;

    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction, GetComponent<Rigidbody2D>().velocity.y);
        if (direction > 0 && !facingRight)
            Flip();
        else if (direction < 0 && facingRight)
            Flip();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemyWall")
        {
            direction *= -1f;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            direction *= -1f;
        }
    }
}