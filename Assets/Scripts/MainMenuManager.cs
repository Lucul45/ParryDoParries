using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Canvas _mainMenu;
    [SerializeField] private Canvas _tutorialMenu;

    public void Play()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game");
    }

    public void Tuto()
    {
        _mainMenu.gameObject.SetActive(false);
        _tutorialMenu.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void MainMenu()
    {
        _mainMenu.gameObject.SetActive(true);
        _tutorialMenu.gameObject.SetActive(false);
    }
}
