using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed;

    public float fireDelay;
    public int fireQuantity;

    public GameObject projectile;

    public Animator deadAnimator;

    float fireTimer = 1;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

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

            Die();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
        }
    }

    void Die()
    {
        deadAnimator.SetBool("dead", true);
        Destroy(this.transform.Find("Fx").gameObject);

        Destroy(gameObject, 0.7f);
        Destroy(this);
    }
}
