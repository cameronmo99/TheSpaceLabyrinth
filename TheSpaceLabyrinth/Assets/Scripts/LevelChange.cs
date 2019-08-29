using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    public Scene NextLevel;
    public string LoadNextlevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            SceneManager.LoadScene(LoadNextlevel);
        }
    }
}
