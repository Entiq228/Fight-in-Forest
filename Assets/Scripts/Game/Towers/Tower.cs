using UnityEngine;

public class Tower : MonoBehaviour
{
    public int health;
    public int cost;

    public virtual bool LoseHealth(int amount)
    {
        health -= amount;
        if (health == 0)
        {
            Die();
            return true;
        }
        return false;
    }
    public void Die()
    {
        Debug.Log("Tower is dead");
        Destroy(gameObject);
    }
}
