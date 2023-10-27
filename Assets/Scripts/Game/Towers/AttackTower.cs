using System.Collections;
using UnityEngine;

public class AttackTower : Tower
{
    //FIELDS
    //Damage
    public int damage;
    //Prefab (Shooting Item)
    public GameObject prefab_shootItem;
    //Shoot interval
    public float interval;

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
}
