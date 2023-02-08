using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    private float jumpforce;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    public GameObject player;
    float player_coord, enemy_coord;
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveSpeed = 2f;
        jumpforce = 8f;
        coll = GetComponent<BoxCollider2D>();
        bool i = false;
        var watch = new Stopwatch();
        watch.Start();

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump()
    {

        player_coord = player.transform.position.x;
        enemy_coord = this.transform.position.x;
        UnityEngine.Debug.Log("jump");
        if (IsGrounded() == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }

        if (IsGrounded() == false)
        {
            if (player_coord <= enemy_coord)
            {
                direction = -1;
            }
            else if (player_coord >= enemy_coord)
            {
                direction = +1;
            }
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        }


    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .01f, jumpableGround);
    }

}
