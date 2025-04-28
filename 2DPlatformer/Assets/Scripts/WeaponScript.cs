using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
    /// <summary>
    /// Префаб снаряда для стрельбы
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    /// Время перезарядки в секундах
    /// </summary>
    public float shootingRate = 1f;
    private float shootCooldown;
    private float tmin = 0.5f;
    private float tmax = 3f;

    void Start()
    {
        this.SetTimer();
    }

    void Update()
    {
        shootCooldown -= Time.deltaTime;
        if (CanAttack)
        {
            Attack();
            this.SetTimer();
        }
    }

    private void SetTimer() => shootCooldown = Random.Range(tmin, tmax);

    /// <summary>
    /// Создайте новый снаряд, если это возможно
    /// </summary>
    public void Attack()
    {
        if (CanAttack)
        {
            // Создайте новый выстрел
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Определите положение
            shotTransform.position = transform.position;

            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                move.direction = this.transform.right; // в двухмерном пространстве это будет справа от спрайта
            }
        }
    }

    /// <summary>
    /// Готово ли оружие выпустить новый снаряд?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0;
        }
    }
}