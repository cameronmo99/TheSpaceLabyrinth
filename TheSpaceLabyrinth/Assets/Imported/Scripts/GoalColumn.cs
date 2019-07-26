using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalColumn : MonoBehaviour
{
    public GameObject Player;
    public Transform PlayerTransform;
    public GameObject GameManager;
    public UIManager UIManager;
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerTransform = Player.transform;
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        UIManager = GameManager.GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //Checks Distance Between the Player and Goal
        if (Vector3.Distance(transform.position , PlayerTransform.position) < 20)
        {
            UIManager.SPWON = true;
        }
        
    }
}
