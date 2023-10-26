using UnityEngine;

public class DefenceTower : MonoBehaviour
{
    //FIELDS
    //Health
    public int health;
    //Cost
    public int cost;

    //METHODS
    //Init
    void Start()
    {
        
    }
    //Lose health
    public void LoseHealth()
    {
        health--;
        if (health == 0)
        {
            Die();
        }
    }
    //Die
    public void Die()
    {
        Debug.Log("Tower is dead");
        Destroy(gameObject);
    }
}
