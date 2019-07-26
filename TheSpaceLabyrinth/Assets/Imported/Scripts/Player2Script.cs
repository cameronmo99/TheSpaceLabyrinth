using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Script : MonoBehaviour
{
    public Rigidbody Player2;
    public float PlayerSpeed;
    public float PlayerSpeedLimit;
    public GameObject Player1Won;
    public GameObject Player2Won;


    void Start()
    {
        Player1Won = GameObject.Find("Player1Won");
        Player2Won = GameObject.Find("Player2Won");
        Player2Won.gameObject.SetActive(false);
    }


    void Update()
    {

        //Gets the Input and Moves the Player
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player2.AddForce(Vector3.left * PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Player2.AddForce(Vector3.right * PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Player2.AddForce(Vector3.forward * PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Player2.AddForce(Vector3.back * PlayerSpeed * Time.deltaTime);
        }

        if (Player2.velocity.magnitude > PlayerSpeedLimit)
        {
            Player2.velocity = Player2.velocity.normalized * PlayerSpeedLimit;
        }
    }

    //Checks for AI or Goal and Loads Relitive Scene.
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "EasySP")
        {
            Player1Won.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }

        if (other.gameObject.name == "HardSP")
        {
            Player1Won.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }

        if (other.gameObject.tag == "Goal")
        {
            Player2Won.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
