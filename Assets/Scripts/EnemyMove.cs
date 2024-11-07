using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private bool move;
    [SerializeField] private GameObject player, enemy;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (move == true)
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = true; 
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
