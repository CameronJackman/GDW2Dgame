using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
}
