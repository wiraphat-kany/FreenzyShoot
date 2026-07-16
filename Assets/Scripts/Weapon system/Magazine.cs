using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    private Transform player;
    private Vector2 diPlayer;
    [SerializeField] private int AmmoUp;

    void Start()
    {
        GameObject  playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        
        if (player != null)
        {
            diPlayer = (player.position - transform.position).normalized;
        }
        else
        {
            diPlayer = Vector2.down;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Classic")
        { 
            var player = col.GetComponent<Shooting>();
            player.PlayerGetMagazineClassic(AmmoUp);
            Destroy(gameObject);
        }
        
        if (col.gameObject.tag == "Odin")
        { 
            var player = col.GetComponent<Shooting>();
            player.PlayerGetMagazineOdin(AmmoUp);
            Destroy(gameObject);
        }
        
        if (col.gameObject.tag == "Sheriff")
        { 
            var player = col.GetComponent<Shooting>();
            player.PlayerGetMagazineSheriff(AmmoUp);
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Sword(Bow)")
        {
            var player = col.GetComponent<Shooting>();
            player.PlayerGetMagazineBow(AmmoUp);
            Destroy(gameObject);
        }

    }
 
    
   
   
   
}
