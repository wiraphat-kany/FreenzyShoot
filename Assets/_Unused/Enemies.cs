using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemies : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHelth;
    
   
    [SerializeField] private Transform player;
    [SerializeField] private float agroRange;
    [SerializeField] private float move;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentHelth = maxHealth;
    }

    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasePlayer();
        }
        
    }

    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(move, 0);
        }
        else    
        {
            rb2d.velocity = new Vector2(-move, 0);
        }
    }

    void StopChasePlayer()
    {

    }
    

    public void TakeDamage(int damage)
    {
        currentHelth -= damage;

        if (currentHelth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
