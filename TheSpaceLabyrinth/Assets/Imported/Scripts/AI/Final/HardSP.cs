using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardSP : BaseAIScript
{
    public float HardSpeed = 5;
    public GameObject GameManager;
    public UIManager UIManager;
    Scene CurrentScene;

    void Start()
    {
        //Gets the GameManager and the Players GameObject and Thier Transform
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        UIManager = GameManager.GetComponent<UIManager>();
        Player1Gameobject = GameObject.FindGameObjectWithTag("Player1");
        Player1Transform = Player1Gameobject.transform;
        Player2Gameobject = GameObject.FindGameObjectWithTag("Player2");
        Player2Transform = Player2Gameobject.transform;
        Speed = HardSpeed;
        //Gets and Chooses Waypoint
        GetNewWaypoint();
        ChooseWaypoint();
        CurrentScene = SceneManager.GetActiveScene();
    }


    void Update()
    {
        //Goes to Target
        GoToTarget();

        //If on SinglePlayer Scene Will Load relivent Scenes
        if (Vector3.Distance(transform.position, Player1Transform.position) < 3)
        {
            if (CurrentScene.name == "SinglePlayer")
            {
                SceneManager.LoadScene("SPLOST");
                UIManager.SPLOST = true;
            }
        }

        if (Vector3.Distance(transform.position, Player2Transform.position) < 3)
        {
            if (CurrentScene.name == "SinglePlayer")
            {
                SceneManager.LoadScene("SPLOST");
                UIManager.SPLOST = true;
            }
        }
    }
}
