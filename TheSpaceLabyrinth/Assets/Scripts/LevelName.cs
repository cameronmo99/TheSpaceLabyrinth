using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelName : MonoBehaviour
{

    public Text LevelNameText;
    public Scene CurrentScene;
    public string SceneName;


    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
        SceneName = CurrentScene.name;
        LevelNameText.text = SceneName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
