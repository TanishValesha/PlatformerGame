using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public AudioSource _audio;
    public AudioClip sound;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void GameLoader()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quitfunction()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void SelectSFX()
    {
        _audio.PlayOneShot(sound);
    }

    public void Button1()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void Button2()
    {
        SceneManager.LoadScene("Level 2");
    }
    
    public void Button3()
    {
        SceneManager.LoadScene("Level 3");
    }
    
    public void Button4()
    {
        SceneManager.LoadScene("Level 4");
    }
    
    public void Button5()
    {
        SceneManager.LoadScene("Level 5");
    }
    
}
