using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpheight;
    public float jumpforce;
    Rigidbody2D rb2d;
    public bool grounded;
    public float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
           if(grounded == true)
            {
                Jump();
                grounded = false;
            }
        
        
    }
    public void Move(float input)
    {
        /*rb2d.AddForce(Vector2.right * horizontalInput * speed);*/
        horizontalInput = input * speed;
    }
    public void Jump()
    {
        rb2d.AddForce(Vector2.up * jumpforce * jumpheight, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
