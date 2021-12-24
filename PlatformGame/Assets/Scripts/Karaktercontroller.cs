using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karaktercontroller : MonoBehaviour
{

    private float myspeedx;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    public bool Onground;
    private bool doublejump;
    [SerializeField] GameObject arrow;
    public float sayac;
     
     

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
     
        myspeedx = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(myspeedx * 7, rb.velocity.y);
        donme();
        zýplama();
        okatma();
        animasyon();
    }
    public void donme()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
             
            sr.flipX = true;
        }
    }
    public void zýplama()
    {

        if (Input.GetKeyDown(KeyCode.W & KeyCode.Space))
        {
            if (Onground==true)
            {
             
                rb.velocity = new Vector2(rb.velocity.x, 5f);
                doublejump = true;
                gameObject.GetComponent<Animator>().SetTrigger("jump");
            }
            else
            {
                if (doublejump==true)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 5f);
                    doublejump = false; 
                }
            }
             
        }
    }

    public void okatma()
    {
        sayac -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
             
            if (sayac<=0)
            {
                GameObject okumuz = Instantiate(arrow, transform.position, Quaternion.identity);// Obje oluþturma prefabdan alýyor.

                if (sr.flipX == false)
                {
                    okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(10f, 0f);
                    okumuz.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(-10f, 0f);
                    okumuz.GetComponent<SpriteRenderer>().flipX = true;
                }
                gameObject.GetComponent<Animator>().SetTrigger("attack");
                sayac = 1f;

            }   
        }
    }
    public void animasyon()
    {
        gameObject.GetComponent<Animator>().SetFloat("hýz", Mathf.Abs(myspeedx)); 
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ENEMY")
        {
            Die();
        }
    }
    void Die()
    { 
        gameObject.GetComponent<Animator>().SetTrigger("die");
        gameObject.GetComponent<Animator>().SetFloat("hýz", 0);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        enabled = false;
    }
}
