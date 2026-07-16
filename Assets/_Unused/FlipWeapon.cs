using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var move = Input.GetAxisRaw("Horizontal");
        if (!Mathf.Approximately(move, 0))
            transform.rotation = move < 0 ? Quaternion.Euler(0, -180, 0) : Quaternion.identity;
    }
}
