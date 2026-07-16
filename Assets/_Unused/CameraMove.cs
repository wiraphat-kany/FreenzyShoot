using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
  
    [SerializeField] private float speed = 5;
    [SerializeField] private float jump = 300f;

    [SerializeField] bool ground;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
      
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float move = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Space) && ground == true && rb2d.velocity.y == 0)
        {
            rb2d.AddForce(Vector2.up * jump);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }


    }



    

}
