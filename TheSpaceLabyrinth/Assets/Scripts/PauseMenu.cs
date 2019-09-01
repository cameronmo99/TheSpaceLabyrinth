using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public string CurrentScene;

    public void MainMenu()
    {
        //Loads the MainMenu
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    public void Save()
    {
        //Saves The Current Scene to PLayer Prefs
        PlayerPrefs.SetString("CurrentScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }

    public void Exit()
    {
        //Quits the Game
        Application.Quit();
    }
}
