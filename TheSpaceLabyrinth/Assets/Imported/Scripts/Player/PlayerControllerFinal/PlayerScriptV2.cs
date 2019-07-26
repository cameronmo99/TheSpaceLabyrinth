﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptV2 : MonoBehaviour
{

    public float speed = 10.0f;
    public float Vertical;
    public float Horizontal;
    public float MaximumX = 25f;
    public float MinimumX = -25f;
    public GameObject Goal;
    public GameObject GameManager;
    public UIManager UIManager;
    public bool EscapeMenu = false;
    public GameObject PauseMenu;

    // Use this for initialization
    void Start()
    {
        //Locks the Cursor and gets the GameManager
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenu = GameObject.Find("PauseMenu");
        Goal = GameObject.FindGameObjectWithTag("Goal");
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        UIManager GameObjectScript = GameManager.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets Info for Controller and Finds the GameManger
        Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(Horizontal, 0, Vertical);
        Goal = GameObject.FindGameObjectWithTag("Goal");
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        UIManager = GameManager.GetComponent<UIManager>();
        //Vertical = Mathf.Clamp(Vertical, MinimumX, MaximumX);


        //Turns the Pause Menu off
        if (EscapeMenu == false)
        {
            PauseMenu.gameObject.SetActive(false);
        }

        //If the Pause Menu is off the TimeScale is normal and locks the Cursor
        if (EscapeMenu == false)
        {
            PauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }

        //If the Pause Menu is on the TimeScale is 0 and unlocks the Cursor
        if (EscapeMenu == true)
        {
            PauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("escape"))
        {
            EscapeMenu = !EscapeMenu;
        }
    }
    //Detects The Goal, AI and Loads relivent Scene
    void OnCollisionStay(Collision col)
    {
        if (gameObject.tag== "Goal")
        {
            UIManager.SPWON = true;
        }

        if (gameObject.name == "EasySP")
        {
            UIManager.SPLOST = true;
        }

        if (gameObject.name == "HardSP")
        {
            UIManager.SPLOST = true;
        }


    }
}