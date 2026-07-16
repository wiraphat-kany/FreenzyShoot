using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLv2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D _collider2D)
    {
        if (_collider2D.gameObject.name == "Player" && GameVariable._keyCount >= 7)
        {
            GameVariable._keyCount -- ;
            Destroy(gameObject);
        }
    }
}
