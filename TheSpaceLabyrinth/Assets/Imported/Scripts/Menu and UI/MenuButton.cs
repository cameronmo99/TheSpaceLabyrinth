using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameObject GameManager;

    //Loads the MainMenu and Destroys the Game Manager
    public void BackToMenu()
    {
        GameManager = GameObject.Find("GameManager");
        SceneManager.LoadScene("MainMenu");
        Destroy(GameManager);
    }

    //Exits the Game
    public void ExitGame()
    {
        Application.Quit();
    }
}
