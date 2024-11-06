using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float horizontal;
    public float jumpPower;
    public GameObject player;
    public float speed = 0f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public bool ePressed;
    private bool isFacingRight = true;

    [SerializeField] WeaponActivate whipActivate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() || Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        if (Input.GetKeyUp(KeyCode.Space) && IsGrounded() || Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        flip();

        //Draw weapon when e pressed
        if (Input.GetKeyDown(KeyCode.E) && whipActivate.ready == true)
        {
            ePressed = true;
            whipActivate.wAtimeElapsed = 0;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            ePressed = false;
        }


    }

    private void FixedUpdate()
    {
        //player speed
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        //check if player is on the ground or not d
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localscale =transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }
}
