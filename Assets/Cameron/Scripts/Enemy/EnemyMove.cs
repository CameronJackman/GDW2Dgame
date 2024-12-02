using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private bool move;
    [SerializeField] private GameObject player, enemy;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource Scream;
    // Start is called before the first frame update
    [SerializeField] bool isFastEnemy;
    void Start()
    {
        move = false;
        spriteRenderer = enemy.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (move == true)
        {
            animator.SetBool("isWalking", true);
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, speed * Time.deltaTime ) * (Time.timeScale/Time.timeScale);
        }
        if (move == false)
        {
            animator.SetBool("isWalking", false);
        }
        
        if (player.transform.position.x < this.transform.position.x)
        {
            spriteRenderer.flipX = true;
        } else if (player.transform.position.x > this.transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = true; 
            if (isFastEnemy==true)
            {
                Debug.Log("fast Enemy");
                Scream.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            move = false;
        }
    }

  
}
