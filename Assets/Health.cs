using UnityEngine;

public class Health : MonoBehaviour
{
    int health = 4;

    [Header("Sprites")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite fullHealth;
    [SerializeField] Sprite slightDamaged;
    [SerializeField] Sprite damaged;
    [SerializeField] Sprite veryDamaged;

    public void TakeDamage(int damage)
    {
        health -= damage;

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

        Destroy(spriteRenderer.gameObject, 0.5f);
        Destroy(this.gameObject);
    }
}
