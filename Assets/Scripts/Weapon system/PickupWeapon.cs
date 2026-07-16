using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    [SerializeField] private GameObject SheriffPrefab;
    [SerializeField] private GameObject ClassicPrefab;
    [SerializeField] private GameObject OdinPrefab;
    [SerializeField] private GameObject SwordPrefab;

   
    
    void Start()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Classic")
        {
            SheriffPrefab.SetActive(false);
            ClassicPrefab.SetActive(true);
            OdinPrefab.SetActive(false);
            SwordPrefab.SetActive(false);
            Destroy(col.gameObject);
        }
        if (col.tag == "Sheriff")
        {
            SheriffPrefab.SetActive(true);
            ClassicPrefab.SetActive(false);
            OdinPrefab.SetActive(false);
            SwordPrefab.SetActive(false);
            Destroy(col.gameObject);
        }

        if (col.tag == "Odin")
        {
            SheriffPrefab.SetActive(false);
            ClassicPrefab.SetActive(false);
            OdinPrefab.SetActive(true);
            SwordPrefab.SetActive(false);
            Destroy(col.gameObject);
        }

        if (col.tag == "Sword")
        {
            SheriffPrefab.SetActive(false);
            ClassicPrefab.SetActive(false);
            OdinPrefab.SetActive(false);
            SwordPrefab.SetActive(true);
            Destroy(col.gameObject);
        }
    }
}
