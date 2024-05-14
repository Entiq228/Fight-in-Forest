using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int health, attackPower;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private float attackInterval;
    private Coroutine attackOrder;
    private Tower detectedTower;

    private SpriteRenderer spriteRenderer;
    
    void Update()
    {
        if (!detectedTower)
        {
            Move();
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    IEnumerator Attack()
    {
        animator.Play("Attack",0,0);
        yield return new WaitForSeconds(attackInterval);
        attackOrder = StartCoroutine(Attack());
    }

    void Move()
    {
        animator.Play("Move");
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
    }

    public void InflictDamage()
    {
        bool towerDied = detectedTower.LoseHealth(attackPower);

        if (towerDied)
        {
            detectedTower = null;
            StopCoroutine(attackOrder);
        }
    }

    public void LoseHealth()
    {
        health--;
        StartCoroutine(BlinkRed());
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (detectedTower) { return; }
        if (collision.TryGetComponent(out detectedTower))
        {
            attackOrder = StartCoroutine(Attack());
        }
    }
}
