using UnityEngine;
using System;
using TMPro;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform barrel1, barrel2;
    [SerializeField] TMP_Text bulletCountText;

    [Header("Anim")]
    [SerializeField] Animator weaponAnimator;

    int bulletCount = 20;
    float shootTimer = 0, timer1 = Int32.MaxValue, timer2 = Int32.MaxValue;

    private void Start()
    {
        bulletCountText.text = bulletCount.ToString();
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;
        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;

        if (Input.GetButton("Fire1") && bulletCount > 0)
        {
            weaponAnimator.SetBool("shooting", true);

            if (shootTimer <= 0)
            {
                shootTimer = 0.5f;
                timer1 = 0.1f;
                timer2 = 0.2f;
            }
        }
        else
        {
            weaponAnimator.SetBool("shooting", false);
        }

        if (shootTimer > 0) HandleShoot();
    }

    void HandleShoot()
    {
        if (timer1 < 0 && bulletCount > 0)
        {
            timer1 = Int32.MaxValue;

            GameObject newBullet = Instantiate(bulletPrefab, barrel1.position, Quaternion.identity);
            Destroy(newBullet, 5);

            bulletCount--;
            bulletCountText.text = bulletCount.ToString();
        }

        if (timer2 < 0 && bulletCount > 0)
        {
            timer2 = Int32.MaxValue;

            GameObject newBullet = Instantiate(bulletPrefab, barrel2.position, Quaternion.identity);
            Destroy(newBullet, 5);

            bulletCount--;
            bulletCountText.text = bulletCount.ToString();
        }
    }
}
