using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class shootingEnemy : MonoBehaviour
{
    private WeaponScript weapon;

    void Awake()
    {
        weapon = GetComponentInChildren<WeaponScript>();
    }

    void Update()
    {
        // автоматическая стрельба
        if (weapon != null && weapon.CanAttack)
        {
            weapon.Attack();
        }
    }
}