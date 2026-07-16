using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    
    
   
    [SerializeField] private float coolDown;
    private float isCoolDown;

    [SerializeField] private float ammo;
    private float currentammo ,Maxammo;
    public Bullet prefabs;
    public Transform offset;
    [SerializeField] private Text txtAmmo;


    

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            Attack();
        }
        txtAmmo.text = ammo.ToString();
    }
    void Attack()
    {
      
        if(Time.time>isCoolDown)
        {
            isCoolDown = Time.time + coolDown;
            ammo -=1;
            Instantiate(prefabs, offset.position, transform.rotation);
        }
    }
    
    
    public void PlayerGetMagazineSheriff(float point)
    {
        ammo = 8 ;
    }
    
    public void PlayerGetMagazineClassic(float point)
    {
        ammo = 7 ;
    }
    
    public void PlayerGetMagazineOdin(float point)
    {
        ammo = 50 ;
    }

    public void PlayerGetMagazineBow(float point)
    {
        ammo = 5;
    }


}
