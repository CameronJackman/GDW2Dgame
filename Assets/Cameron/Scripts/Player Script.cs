using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private float horizontal;
    public float jumpPower;
    public GameObject player;
    public float speed = 0f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioSource footstepsAudio;
    public bool ePressed;
    private bool isFacingRight = true;
    private float pushingForce = 100f;
    [SerializeField] private Menus menus;


    [SerializeField] WeaponActivate whipActivate;

    [SerializeField] private Animator Animator;

    [SerializeField] private TMP_Text bagText;

    [SerializeField] private AudioSource coinCollect, whipSound, damageAudio;

    private float bagCount, totalBags;
    [SerializeField] GameObject LootBags, winScreen;

    [SerializeField] private TMP_Text bagsCollect;


    // Start is called before the first frame update
    void Start()
    {
        totalBags = LootBags.transform.childCount; 
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

        if (horizontal == 0f)
        {
            Animator.SetBool("isWalking", false);
            footstepsAudio.Play();
        }

        if (horizontal != 0f)
        {
            Animator.SetBool("isWalking", true);
            
        }

        //Draw weapon when e pressed
        if (Input.GetKey(KeyCode.E) && whipActivate.ready == true)
        {
            ePressed = true;
            whipActivate.wAtimeElapsed = 0;
            Animator.SetBool("isAttacking", true);
            whipSound.Play();

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            ePressed = false;
            Animator.SetBool("isAttacking", false);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D playerRb = GetComponent<Rigidbody2D>();
        if (collision.gameObject.tag == "Enemy")
        {
            damageAudio.Play();
            playerRb.AddForce(-transform.right * pushingForce);
            
        }

        if (collision.gameObject.tag == "DeathBarrier")
        {
            SceneManager.LoadScene(2);
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LootBag"))
        {
            bagCount++; coinCollect.Play();
            bagText.text = "Bags Collected: " + bagCount;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Win"))
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
            bagsCollect.text = "You Collected:" + bagCount + "/" + totalBags + " Loot Bags";
        }
    }

    


}
