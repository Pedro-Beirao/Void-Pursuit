using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float speed = 1;

    [Header("Fixed")]
    [SerializeField] Vector3 direction;

    [Header("Seeker")]
    [SerializeField] bool seekPlayer;

    void Start()
    {
        if (seekPlayer)
        {
            GameObject seekedObject = GameObject.FindGameObjectWithTag("Player");

            if (seekedObject)
                direction = seekedObject.transform.position - transform.position;
            else
                direction = Vector3.left;
        }

        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
    }

    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0).normalized * Time.deltaTime * speed;
        if (transform.position.x > 9 || transform.position.x < -9) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.CompareTag("EnemyBullet") && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
