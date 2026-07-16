using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Bullet", menuName="Weapon/Bullet")]
public class BulletData : ScriptableObject 
{

    [Header("Shooting")]
    public float damage;

    [Header("Speed")]
    public float speed;
    
}
