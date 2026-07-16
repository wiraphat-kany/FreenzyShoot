using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float maxHp, hp;
    [SerializeField] HpBar hpBar;
    [SerializeField] private float speed = 6;
    [SerializeField] private float jump = 250f;
    //[SerializeField] private float ammo = 0f;
    [SerializeField] private float maxAmmo;
   //[SerializeField] private Text txtAmmo;
    //[SerializeField] private float ammoUp;

    [SerializeField] bool ground;

    private Animator anim;
    
   
    private Rigidbody2D rb2d;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        hp = maxHp;
        hpBar.SetHealth(hp, maxHp);
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
        
        if (Input.GetKeyDown(KeyCode.W) && ground == true && rb2d.velocity.y == 0)
        {
            rb2d.AddForce(Vector2.up * jump);

        }

        
        Flip();

        Animation();

       //txtAmmo.text = ammo.ToString();
        //Attack();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }


    }


    public void EnemyTakeDamage(float damage)
    {
        hp -= damage;
        hpBar.SetHealth(hp, maxHp);
        if (hp <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Flip()
    {
         float move = Input.GetAxisRaw("Horizontal");
         if (!Mathf.Approximately(move, 0))
             transform.rotation = move < 0 ? Quaternion.Euler(0, -180, 0) : Quaternion.identity;
    }

    public void PlayerGetHpPotion(float point)
    {
        hp += point;
        hpBar.SetHealth(hp, maxHp);
    }
    
    void Animation()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("WALK", true);
        }
        else
        {
            anim.SetBool("WALK", false);
        }
    }

}
