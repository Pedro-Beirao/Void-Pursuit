using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] GameObject main;
    [SerializeField] GameObject topBomb;
    [SerializeField] GameObject bottomBomb;
    [SerializeField] GameObject shield;

    void Update()
    {
        if (!topBomb && !bottomBomb && shield)
            Destroy(shield);

        if (transform.position.x < 7.5) return;
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
