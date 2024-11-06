using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActivate : MonoBehaviour
{
    [SerializeField] private PlayerScript Player;
    [SerializeField] private float coolDown;
    [SerializeField] private GameObject weapon;
    public float wAtimeElapsed;
    public bool ready;

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
        }

        wAtimeElapsed += Time.deltaTime;
        if (wAtimeElapsed >= coolDown)
        {
            ready = true;
        }
        else
        {
            ready = false;
        }
    }



}
