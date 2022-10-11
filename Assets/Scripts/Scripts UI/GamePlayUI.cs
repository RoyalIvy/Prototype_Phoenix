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

    public void Pause() // ������� � ����� �����
    {
        isPaused = true;

        Time.timeScale = 0; 
        
        PauseMenuOn();
    }

    public void Resume() // ����������� � ���� 
    {
        isPaused=false;

        Time.timeScale = 1; 

        PauseMenuOff();
    }

    public void MainMenu() // ����� � ������� ����
    {
        SceneManager.LoadScene("Menu");

        Time.timeScale = 1;
    }

    private void PauseMenuOn() // ��������� ���������� ���� ����� 
    {
        if (isPaused)
        {
            pauseUI.SetActive(true);
            pauseButton.SetActive(false);
        }
        
    }

    private void PauseMenuOff() // ���������� ���������� ���� �����
    {
        if (!isPaused)
        {
            pauseUI.SetActive(false);
            pauseButton.SetActive(true);
        }
    }
}
