using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{

    public float health;
    private float maxHealth;

    [SerializeField] GameObject healthPot;
    private int rand;
    
    // Start is called before the first frame update
    void Start()
    {
        //what ever health is set is equal to the maxhealth
        maxHealth = health;

        rand = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damageAmount)
    {
        //takes health away from player
        health -= damageAmount;

        if (health <=0 && gameObject.activeInHierarchy)
        {
            dropHealthPot();
            gameObject.SetActive(false);

            if (gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(2);
            }
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

    private void dropHealthPot()
    {
        
        if(rand == 2 && gameObject.CompareTag("Enemy"))
        {
                var obj = Instantiate(healthPot, gameObject.transform.position, Quaternion.identity);
        }
    }
}
