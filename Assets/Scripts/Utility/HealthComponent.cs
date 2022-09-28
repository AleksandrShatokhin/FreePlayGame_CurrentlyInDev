using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int health;

    public int GetHealth() => health;

    public void ChangeHealth(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GetComponentInParent<IDeathable>().Kill();
        }
        else
        {
            GetComponentInParent<IDeathable>().TakeDamage(damage);
        }
    }
}