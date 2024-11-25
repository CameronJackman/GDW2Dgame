using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whip : MonoBehaviour
{


    [SerializeField] private float WhipDamage;
    private Vector2 whipcoll, target;
    [SerializeField] GameObject whipLength, whipStart;
    [SerializeField] private float travelSpeed;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        whipcoll = gameObject.transform.position;
        target = whipLength.transform.position;
        float step = travelSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        if(gameObject.transform.position == whipLength.transform.position)
        {
            gameObject.transform.position = whipStart.transform.position;
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when collide with enemy deals damage to that enemys health
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(WhipDamage);
        }
    }
}
