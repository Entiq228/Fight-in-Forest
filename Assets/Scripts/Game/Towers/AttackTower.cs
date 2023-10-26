using System.Collections;
using UnityEngine;

public class AttackTower : MonoBehaviour
{
    //FIELDS
    //Health
    public int health;
    //Damage
    public int damage;
    //Prefab (Shooting Item)
    public GameObject prefab_shootItem;
    //Shoot interval
    public float interval;
    //Cost
    public int cost;

    //METHODS
    //Init (Start the shooting interval)
    void Start()
    {
        //Start the shooting interval
        StartCoroutine(ShootDeleay());
    }
    //Interval for shooting
    IEnumerator ShootDeleay()
    {
        yield return new WaitForSeconds(interval);
        //Shoot item method
        ShootItem();
        StartCoroutine(ShootDeleay());
    }
    //Shoot item
    void ShootItem()
    {
        //Instantiate shoot item
        GameObject shotItem = Instantiate(prefab_shootItem, transform);
        //Set its values
        shotItem.GetComponent<ShootItem>().Init(damage);
    }
    //Lose health
    public void LoseHealth()
    {
        health--;
        if(health <= 0)
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
