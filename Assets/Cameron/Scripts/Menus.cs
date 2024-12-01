using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private AudioSource buttonPress;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
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
        buttonPress.Play();
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        buttonPress.Play();
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void playGame()
    {
        buttonPress.Play();
        SceneManager.LoadScene(1);
    }

    public void stopGame()
    {
        buttonPress.Play();
        Application.Quit();
        EditorApplication.isPlaying = false;
    }

    public void restartGame()
    {
        buttonPress.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenu()
    {
        buttonPress.Play();
        SceneManager.LoadScene(0);
    }

    

}
