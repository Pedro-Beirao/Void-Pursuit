using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1;

    [Header("Normal")]
    public Vector3 direction;

    [Header("Seeker")]
    public bool seekPlayer;

    void Start()
    {
        if (seekPlayer)
        {
            Transform seekTransform = GameObject.FindGameObjectWithTag("Player").transform;
            direction = seekTransform.position - transform.position;
        }

        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
    }

    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0).normalized * Time.deltaTime * speed;
    }
}
