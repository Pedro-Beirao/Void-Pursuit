using UnityEngine;
using System.Collections;
using TMPro;

public class Boss : MonoBehaviour
{
    [SerializeField] float speed;

    [Header("Sprites")]
    [SerializeField] GameObject main;
    [SerializeField] GameObject topBomb;
    [SerializeField] GameObject bottomBomb;
    [SerializeField] GameObject shield;

    [Header("Final")]
    [SerializeField] GameObject finalUI;
    [SerializeField] TMP_Text scoreText;

    float elapsedTime = 0;
    int score = 0;
    bool youwon = false;

    void Update()
    {

        elapsedTime += Time.deltaTime;
        score = KillCounter.killCount * 20 - ((int)elapsedTime);

        if (!topBomb && !bottomBomb && shield)
            Destroy(shield);

        if (!main && !youwon)
        {
            youwon = true;
            Final();
        }

        if (transform.position.x < 7.5) return;
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void Final()
    {
        // gameUI.SetActive(false);
        scoreText.text = "Score: " + score.ToString();
        finalUI.SetActive(true);
    }
}
