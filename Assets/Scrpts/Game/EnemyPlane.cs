using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float shootDelay = 0.2f;
    private float lastShoot = 0;

    private void FixedUpdate()
    {
        MoveDown();
        Shoot();
    }

    private void Shoot()
    {
        if (lastShoot + shootDelay > Time.time) return;
        lastShoot = Time.time;
        var bullet = Instantiate(bulletPrefab, transform);
        bullet.transform.position = transform.position;
        (bullet.transform as RectTransform).anchoredPosition += (transform as RectTransform).sizeDelta.y / 2 * Vector2.down;
        bullet.IsShootPlayer = false;
        bullet.transform.parent = transform.parent;
    }

    private void MoveDown()
    {
        (transform as RectTransform).anchoredPosition += Vector2.down * moveSpeed;
    }
}
