using UnityEngine;

/// <summary>
/// Поведение снаряда
/// </summary>
public class ShotScript : MonoBehaviour
{
    void Start()
    {
        // Ограниченное время жизни, чтобы избежать утечек
        Destroy(gameObject, 5); // 5 секунд
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "Coin")
        {
            Destroy(gameObject);
        }
    }
}