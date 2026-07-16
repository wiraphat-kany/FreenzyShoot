using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckReSpawn : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
