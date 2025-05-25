using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject levels;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject settings;

    [SerializeField] private AudioSource click;

    public void LoadLevel(int level)
    {
        click.Play();
        SceneManager.LoadSceneAsync(level);
    }

    public void OpenSettings()
    {
        click.Play();
        settings.SetActive(true);
        menu.SetActive(false);
    }
    
    public void OpenLevels()
    {
        click.Play();
        levels.SetActive(true);
        menu.SetActive(false);
    }
    
    public void OpenMenu()
    {
        click.Play();
        menu.SetActive(true);
        settings.SetActive(false);
        levels.SetActive(false);
    }
    
    public void QuitGame()
    {
        click.Play();
        Application.Quit();
    }
}
