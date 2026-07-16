using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float xStartPos,xEndPos,yStartPos,yEndPos;
   /* [SerializeField] private float delaySpawn = 1f;
    float timer;
    bool spawn;*/




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            Vector2 enemySpawn = new Vector2(Random.Range(xStartPos, xEndPos), Random.Range(yStartPos, yEndPos));
            Instantiate(enemy, enemySpawn, transform.rotation);
           // spawn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
       /* if (collision.gameObject.tag == "Player")
        {
            spawn = false;
        }*/
    }


















    /*  if (spawn == true)
       {
           timer -= Time.fixedDeltaTime;
           if (timer <= 0)
           {
               Vector2 enemySpawn = new Vector2(Random.Range(xStartPos,xEndPos), Random.Range(yStartPos,yEndPos));
               Instantiate(enemy, enemySpawn, transform.rotation);
               timer = delaySpawn;
           }
       }*/
}
