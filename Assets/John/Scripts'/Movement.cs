using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpheight;
    public float jumpforce;
    public float horizontalInput;
    public int JumpNum;
    public bool grounded;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    public void Move(float input)
    {
        /*rb2d.AddForce(Vector2.right * horizontalInput * speed);*/
        horizontalInput = input * speed;
    }
    public void Jump()
    {
        if(grounded == true|| JumpNum == 1)
        {
            rb2d.AddForce(Vector2.up * jumpforce * jumpheight, ForceMode2D.Force);
            grounded = false;
            JumpNum = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            JumpNum = 1;
        }
    }
}