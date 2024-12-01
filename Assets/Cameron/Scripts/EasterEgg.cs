using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    [SerializeField] AudioSource kermit;
    [SerializeField] GameObject backAudio, footSteps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        backAudio.SetActive(false); footSteps.SetActive(false);
        kermit.Play();
        Time.timeScale = 0.25f;
    }
}
