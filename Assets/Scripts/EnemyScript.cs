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
    public float damageTaken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemyhealth.health <= 0)
        {
            Enemy.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Playerheath.TakeDamage(damage);
        }

        if(collision.gameObject.tag == "whip")
        {
            Enemyhealth.TakeDamage(damageTaken);
        }

        
        
    }



    
}
