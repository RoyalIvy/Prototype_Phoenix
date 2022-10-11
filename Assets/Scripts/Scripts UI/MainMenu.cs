using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject subOptions;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        subOptions.SetActive(true);
    }

    public void BackToMenu()
    {
        subOptions.SetActive(false);
        mainMenu.SetActive(true);
    }
}
