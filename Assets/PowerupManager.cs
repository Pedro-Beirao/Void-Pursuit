using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    Health health;

    void Start()
    {
        health = GetComponent<Health>();
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
    }
}
