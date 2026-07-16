using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHp,hp;
    [SerializeField] HpBar hpBar;
    [SerializeField] private float damage = 20;

    Rigidbody2D rb2d;
    
    //Follow Player
   

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        hp = maxHp;
        hpBar.SetHealth(hp, maxHp);
    }

   

    // Update is called once per frame
   public void PlayerTakeDamage(float damage)
    {
        hp -= damage;
        hpBar.SetHealth(hp, maxHp);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
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
