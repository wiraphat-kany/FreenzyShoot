using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D _collider2D)
    {
        if (_collider2D.gameObject.name == "Player" && GameVariable._keyCount >= 4)
        {
            GameVariable._keyCount -- ;
            Destroy(gameObject);
        }
    }
}
