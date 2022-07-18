using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public bool onGround;

    

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    

    public int playerRange;
    
    public Vector2Int mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
    private void FixedUpdate()
    {

        

    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float jump = Input.GetAxisRaw("Jump");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontal * moveSpeed, rb.velocity.y);




        if (horizontal > 0)
            transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        else if (horizontal < 0)
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);


        if (onGround)
        {
            movement.y = jumpForce;
        }
            
        
        rb.velocity = movement;
    }
}
