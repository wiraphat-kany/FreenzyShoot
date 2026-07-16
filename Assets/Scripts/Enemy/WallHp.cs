using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHp : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHelth;
    [SerializeField] private GameObject player;
    private float damage = 0;

     Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentHelth = maxHealth;
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }
    
    public void PlayerTakeDamage(float damage)
    {
        currentHelth -= damage;

        if (currentHelth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<Player>();
        if (player)
        {
            player.EnemyTakeDamage(damage);
        }
    }
}
