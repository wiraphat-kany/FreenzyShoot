using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Bullet prefabs;

    public Transform offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }


    void Attack()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefabs, offset.position, transform.rotation);
        }
    }
}
