using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    private float movehorizontal;
    private float movevertical;
    private float jumpforce;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    public GameObject player;
    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveSpeed = 7f;
        jumpforce = 10f;
        coll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Thingy());
    }

    IEnumerator Thingy()
    {
        //target = GameObject.FindWithTag("Player").transform;
        //Vector3 forwardAxis = new Vector3(0, 0, -1);




        bool i = true;

        while (i == true)
        {
            Debug.Log("jump");

            rb.velocity = new Vector2(rb.velocity.x, jumpforce);

            if (IsGrounded() == false)
            {
                //rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
                //transform.LookAt(target.position, forwardAxis);
                //Debug.DrawLine(transform.position, target.position);
                //transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
                //transform.position -= transform.TransformDirection(Vector2.up) * 0.0000001f;

            }




            yield return new WaitForSeconds(2);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .01f, jumpableGround);
    }

}
