using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    Health health;
    Shooting shooting;

    void Start()
    {
        health = GetComponent<Health>();
        shooting = GetComponent<Shooting>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("ShieldPowerup"))
        {
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
    }
}
