using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [Space]

    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject pauseButton;
    
    private bool isPaused;

    public void Pause() // переход в режим паузы
    {
        isPaused = true;

        Time.timeScale = 0; 
        
        PauseMenuOn();
    }

    public void Resume() // возвращение в игру 
    {
        isPaused=false;

        Time.timeScale = 1; 

        PauseMenuOff();
    }

    public void MainMenu() // выход в главное меню
    {
        SceneManager.LoadScene("Menu");

        Time.timeScale = 1;
    }

    private void PauseMenuOn() // включение интерфейса меню паузы 
    {
        if (isPaused)
        {
            pauseUI.SetActive(true);
            pauseButton.SetActive(false);
        }
        
    }

    private void PauseMenuOff() // выключение интерфейса меню паузы
    {
        if (!isPaused)
        {
            pauseUI.SetActive(false);
            pauseButton.SetActive(true);
        }
    }
}
