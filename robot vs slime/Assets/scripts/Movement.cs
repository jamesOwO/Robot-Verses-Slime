using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    private float movehorizontal;
    private float movevertical;
    private float jumpforce;
    private bool isjumping;
    public Animator animator;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    public GameObject menuUI;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        moveSpeed = 7f;
        jumpforce = 10f;
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (menuUI.activeInHierarchy == false)
        {


            // movement left and right
            movehorizontal = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(movehorizontal * moveSpeed, rb.velocity.y);

            // faces direction of movement
            if (movehorizontal > 0.1)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (movehorizontal < -0.1)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            // jump
            if (Input.GetButtonDown("Jump"))
            {
                if (IsGrounded())
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                    animator.SetBool("IsJumping", true);

                }
            }

            // checks if touching ground

            if (IsGrounded() == true)
            {
                animator.SetBool("IsJumping", false);
                animator.SetFloat("Speed", Mathf.Abs(movehorizontal));
            }
            else
            {
                animator.SetBool("IsJumping", true);
            }

        }
        

    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .01f, jumpableGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            menuUI.SetActive(true);
        }
    }
}
