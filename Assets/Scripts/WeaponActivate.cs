using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActivate : MonoBehaviour
{
    [SerializeField] private PlayerScript Player;
    public float heldOutOnAttackTime;
    [SerializeField] private GameObject weapon;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Attack
        if (Player.ePressed == true)
        {
            weapon.SetActive(true);
            Debug.Log("E Presed");
        }
        if (weapon.activeInHierarchy)
        {
            Debug.Log("Active");
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= heldOutOnAttackTime)
            {
                weapon.SetActive(false);
                timeElapsed = 0f;
            }
        }
    }



}
