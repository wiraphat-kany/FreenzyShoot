using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFall : MonoBehaviour
{
    private Rigidbody2D rb;
   
    [SerializeField] private GameObject player;
    
    private BoxCollider2D boxCollider2D;
    public float distance;
    private bool isFalling;
    
    [SerializeField] private float HpDown = -15f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        Physics2D.queriesStartInColliders = false;
        if (isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            
            Debug.DrawRay(transform.position , Vector2.down * distance , Color.red);
            

            if (hit.transform != null)
            {
                if (hit.transform.tag == "Player")
                {
                    rb.gravityScale = 4;
                    isFalling = true;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") 
        {
            Destroy(gameObject);
        }
        else
        {
            rb.gravityScale = 0;
            boxCollider2D.enabled = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        { 
            var player = col.GetComponent<Player>();
            player.PlayerGetHpPotion(HpDown);
        }
        
    }

}


