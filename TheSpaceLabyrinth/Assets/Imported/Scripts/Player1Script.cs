using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Script : MonoBehaviour
{
    public Rigidbody Player1;
    public float PlayerSpeed;
    public float PlayerSpeedLimit;
    public bool EscapeMenu = false;
    public GameObject PauseMenu;
    public GameObject Player1Won;
    public GameObject Player2Won;


    void Start()
    {
        //Finds the Menus
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenu = GameObject.Find("PauseMenu");
        Player1Won = GameObject.Find("Player1Won");
        Player2Won = GameObject.Find("Player2Won");
        Player1Won.gameObject.SetActive(false);
    }


    void Update()
    {
        //Gets the Input and Moves the Player
        if (Input.GetKey(KeyCode.A))
        {
            Player1.AddForce(Vector3.left * PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Player1.AddForce(Vector3.right * PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Player1.AddForce(Vector3.forward * PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Player1.AddForce(Vector3.back * PlayerSpeed * Time.deltaTime);
        }

        if (Player1.velocity.magnitude > PlayerSpeedLimit)
        {
            Player1.velocity = Player1.velocity.normalized * PlayerSpeedLimit;
        }

        if (EscapeMenu == false)
        {
            PauseMenu.gameObject.SetActive(false);
        }

        if (EscapeMenu == false)
        {
            PauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }

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

    //Checks for AI or Goal and Loads Relitive Scene.
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "EasySP")
        {
            Player2Won.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }

        if (other.gameObject.name == "HardSP")
        {
            Player2Won.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }

        if(other.gameObject.tag == "Goal")
        {
            Player1Won.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
