using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private HitableObject hitableObject;
    [SerializeField] private float damage;
    [SerializeField] private Sprite playerBulletSprite;
    [SerializeField] private Sprite enemyBulletSprite;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private ContactFilter2D filter;
    private bool isShootPlayer;

    public bool IsShootPlayer
    {
        get
        {
            return isShootPlayer;
        }
        set
        {
            image.sprite = value ? playerBulletSprite : enemyBulletSprite;
            hitableObject.hitableType = value ? HitableObjectType.playerBullet : HitableObjectType.enemyBullet;
            isShootPlayer = value;
        }
    }

    private void Start()
    {
        StartCoroutine(DestroyCoroutine());
        Vector2 moveDirection = IsShootPlayer ? Vector2.up * speed : Vector2.down * speed;
        GetComponent<Rigidbody2D>().velocity = moveDirection;
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        RaycastHit2D[] results = new RaycastHit2D[10];
        Physics2D.BoxCast(transform.position, Vector2.one * 0.1f, 0, Vector2.zero, filter, results);
        Collider2D targetCollider = null;
        foreach (var r in results)
        {
            if (r.collider == null) return;
            if (r.collider.CompareTag(isShootPlayer ? "Enemy" : "Player"))
            {
                targetCollider = r.collider;
                break;
            }
        }
        if (targetCollider == null) return;
        var hitableObject = targetCollider.gameObject.GetComponent<HitableObject>();
        if (!hitableObject) return;
        if (hitableObject.hitableType == HitableObjectType.enemy) GameManager.instance.AddPoints();
        StopAllCoroutines();
        Debug.Log($"collided {targetCollider.name}");
        hitableObject.ReduceHealth(damage);
        Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
