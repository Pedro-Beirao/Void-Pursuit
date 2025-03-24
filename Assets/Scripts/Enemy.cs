using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int health = 1;

    [SerializeField] float fireDelay;
    [SerializeField] int fireQuantity;

    [SerializeField] GameObject projectile;

    [SerializeField] Animator deadAnimator;

    float fireTimer = 1;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x > 8.5) return;
        if (transform.position.x < -9) Destroy(gameObject);

        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0)
        {
            fireTimer = fireDelay;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        for (int i = 0; i < fireQuantity; i++)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            Destroy(newProjectile, 5);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);

            TakeDamage(1);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        KillCounter.killCount++;

        if (deadAnimator) deadAnimator.SetBool("dead", true);

        Transform Fx = transform.Find("Fx");
        if (Fx) Destroy(Fx.gameObject);

        Destroy(gameObject, 0.7f);
        Destroy(this);
    }
}
