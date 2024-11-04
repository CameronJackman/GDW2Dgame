using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float health;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health > 0)
        {
            Debug.Log("Player Took Damage");
        }
        else
        {
            Debug.Log("Player Dead");
        }
    }

    public void AddHealth(float value)
    {
        health += value;
        if (health> maxHealth)
        {
            health = maxHealth;
        }

    }
}
