using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    [SerializeField] float speed;

    [Header("Sprites")]
    [SerializeField] GameObject main;
    [SerializeField] GameObject topBomb;
    [SerializeField] GameObject bottomBomb;
    [SerializeField] GameObject shield;

    [Header("Final")]
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject finalUI;

    void Update()
    {
        if (!topBomb && !bottomBomb && shield)
            Destroy(shield);

        if (!main)
            Final();

        if (transform.position.x < 7.5) return;
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void Final()
    {
        gameUI.SetActive(false);
        finalUI.SetActive(true);
    }
}
