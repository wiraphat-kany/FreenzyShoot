using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWeapon : MonoBehaviour
{
   
    [SerializeField] private float itemSpeed = 15f;
    [SerializeField] private int AmmoUp;
    
    


    private void Update()
    {
        transform.position += Vector3.down * itemSpeed * Time.deltaTime;
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


