using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Health Playerheath;
    [SerializeField] private Health Enemyhealth;
    [SerializeField] private float damage;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float speed=0.5f;
    public float damageTaken;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //kill enemy when health is 0 or less
        if (Enemyhealth.health <= 0)
        {
            Enemy.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when colliding with player deal damage
        if(collision.gameObject.tag == "Player")
        {
            Playerheath.TakeDamage(damage);
        }

        //when colliding with the whip it takes damage 
        if(collision.gameObject.tag == "Whip")
        {
            Enemyhealth.TakeDamage(damageTaken);
        }

    }






}
