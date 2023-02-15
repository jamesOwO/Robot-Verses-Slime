using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    private float movehorizontal;
    private float jumpforce;
    public Animator animator;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    public GameObject menuUI, heart1, heart2, heart3;
    int health = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        moveSpeed = 7f;
        jumpforce = 10f;
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (health == 0)
        {
            heart1.SetActive(false);
        }

        if (health == 1)
        {
            heart2.SetActive(false);
        }

        if (health == 2)
        {
            heart3.SetActive(false);
        }



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
        if (collision.gameObject.tag == "Enemy")
        {
            health = health - 1;
            Debug.Log("ouch");
        }
        if (collision.gameObject.tag == "Death")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
