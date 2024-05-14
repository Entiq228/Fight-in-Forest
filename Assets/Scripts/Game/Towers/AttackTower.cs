using System.Collections;
using UnityEngine;

public class AttackTower : Tower
{
    public int damage;
    public GameObject prefab_shootItem;
    public float interval;

    void Start()
    {
        StartCoroutine(ShootDeleay());
    }
    IEnumerator ShootDeleay()
    {
        yield return new WaitForSeconds(interval);
        ShootItem();
        StartCoroutine(ShootDeleay());
    }
    void ShootItem()
    {
        GameObject shotItem = Instantiate(prefab_shootItem, transform);
        shotItem.GetComponent<ShootItem>().Init(damage);
    }
}
