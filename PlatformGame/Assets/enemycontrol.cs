using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontrol : MonoBehaviour
{
    public bool onground;
    private Rigidbody2D rb;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
        rb=gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f,mask);
        if (hit.collider !=null)
        {
            onground = true;
        }
        else
        {
            onground = false;
        }
        rb.velocity = new Vector2(transform.right.x * 3f, 0);
        if (!onground)
        {
            transform.eulerAngles += new Vector3(0, 180f, 0);
        }
    }
}
