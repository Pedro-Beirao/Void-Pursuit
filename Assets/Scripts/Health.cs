using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Health : MonoBehaviour
{
    int health = 4;
    float shieldTimer = 0;

    [Header("Sprites")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite fullHealth;
    [SerializeField] Sprite slightDamaged;
    [SerializeField] Sprite damaged;
    [SerializeField] Sprite veryDamaged;
    [SerializeField] GameObject shield;

    public GameObject shieldPowerup;

    void Update()
    {
        shieldTimer -= Time.deltaTime;

        if (shield)
            shield.SetActive(shieldTimer > 0);
    }

    public void TakeDamage(int damage)
    {
        if (shieldTimer > 0) return;
        if (shieldPowerup)
        {
            Destroy(shieldPowerup);
            shieldTimer = 2;
            return;
        }

        health -= damage;
        shieldTimer = 2;

        if (health == 4)
            spriteRenderer.sprite = fullHealth;
        else if (health == 3)
            spriteRenderer.sprite = slightDamaged;
        else if (health == 2)
            spriteRenderer.sprite = damaged;
        else if (health == 1)
            spriteRenderer.sprite = veryDamaged;
        else if (health <= 0)
            Die();
    }

    void Die()
    {
        Animator animator = spriteRenderer.gameObject.GetComponent<Animator>();
        animator.enabled = true;
        spriteRenderer.gameObject.GetComponent<Animator>().SetBool("dead", true);
        spriteRenderer.transform.SetParent(null);

        StartCoroutine(GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>().RestartScene(3));

        Destroy(GetComponent<Shooting>());
        Destroy(GetComponent<Movement>());
        Destroy(GetComponent<PowerupManager>());
        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
    }
}
