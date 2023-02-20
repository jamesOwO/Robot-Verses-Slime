using System.Diagnostics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public float jumpforce;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    public GameObject player;
    float player_coord, enemy_coord;
    float direction;
    public GameObject menuUI;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        coll = GetComponent<BoxCollider2D>();
        var watch = new Stopwatch();
        watch.Start();

    }

    // Update is called once per frame
    void Update()
    {
        if (menuUI.activeInHierarchy == false)
        {
            Jump();
        }
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
