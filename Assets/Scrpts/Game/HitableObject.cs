using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HitableObject : MonoBehaviour
{
    public HitableObjectType hitableType;
    public float totalHealth = 1;
    public float Health { get; private set; } = 1;

    private void Start()
    {
        Health = totalHealth;
    }

    public void ReduceHealth(float damage)
    {
        Health -= damage;
        if (hitableType == HitableObjectType.player && Health <= 0)
        {
            GameManager.instance.EndGame(false);
        }
        if (Health <= 0)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}

[Serializable]
public enum HitableObjectType
{
    enemy,
    enemyBullet,
    playerBullet,
    player
}
