using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float health;
    [SerializeField] private float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        //what ever health is set is equal to the maxhealth
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {
        //takes health away from player
        health -= damageAmount;

        if (health > 0)
        {
            Debug.Log("Player Took Damage");
        }
        else
        {
            Debug.Log("Player Dead");
            Destroy(gameObject);
        }
    }

    public void AddHealth(float value)
    {
        //if any health is getting added it will run this method
        health += value;
        if (health> maxHealth)
        {
            health = maxHealth;
        }

    }
}
