using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Transform player;
    private Vector2 diPlayer;
    //private HpBar gc;
    [SerializeField] private float HpDown = -15f;

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
        if (col.gameObject.tag == "Player")
        { 
            var player = col.GetComponent<Player>();
            player.PlayerGetHpPotion(HpDown);
        }
        
    }
}
