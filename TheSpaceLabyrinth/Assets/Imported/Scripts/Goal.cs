using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject GoalGameObject;
    public GameObject GameManager;
    public UIManager UIManager;

    void Start()
    {
        //Gets the GameManager
        GoalGameObject = GameObject.FindGameObjectWithTag("Goal");
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        UIManager = GameManager.GetComponent<UIManager>();
    }

    //Checks Objects and Sets GameManager Bools
    void OnCollisionStay(Collision col)
    {
        if (gameObject.name == "Player")
        {
            UIManager.SPWON = true;
        }
        if (gameObject.tag == "Player1")
        {
        }
        if (gameObject.name == "Player2")
        {
            UIManager.SPWON = true;
        }
    }
}
