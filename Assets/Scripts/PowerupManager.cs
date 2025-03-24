using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    Health health;
    Shooting shooting;
    Movement movement;

    [SerializeField] GameObject normalEngine;
    [SerializeField] GameObject boostEngine;

    float boostTimer = 0;

    void Start()
    {
        health = GetComponent<Health>();
        shooting = GetComponent<Shooting>();
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
            boostEngine.SetActive(true);
            normalEngine.SetActive(false);
            movement.speed = movement.boostSpeed;
        }
        else
        {
            boostEngine.SetActive(false);
            normalEngine.SetActive(true);
            movement.speed = movement.normalSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("ShieldPowerup"))
        {
            if (health.shieldPowerup) return;
            health.shieldPowerup = collider.gameObject;
            collider.transform.parent = transform;
            collider.transform.localPosition = Vector3.zero;
            Destroy(collider);
        }
        else if (collider.gameObject.CompareTag("Ammo"))
        {
            shooting.ammo += 20;
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.CompareTag("BoostPowerup"))
        {
            boostTimer = 5;
            Destroy(collider.gameObject);
        }
    }
}
