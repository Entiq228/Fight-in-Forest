using UnityEngine;

public class ShootItem : MonoBehaviour
{
    [SerializeField] private Transform graphics;
    [SerializeField] private int damage;
    [SerializeField] private float flySpeed, rotateSpeed;

    public void Init(int dmg)
    {
        damage = dmg;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemy))
        {
            Debug.Log("Shot the Enemy");
            enemy.LoseHealth();
            Destroy(gameObject);
        }
        if (collision.tag == "Out")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Rotate();
        FlyForward();
    }
    void Rotate()
    {
        graphics.Rotate(new Vector3(0,0,-rotateSpeed * Time.deltaTime));
    }
    void FlyForward()
    {
        transform.Translate(transform.right * flySpeed * Time.deltaTime);
    }
}
