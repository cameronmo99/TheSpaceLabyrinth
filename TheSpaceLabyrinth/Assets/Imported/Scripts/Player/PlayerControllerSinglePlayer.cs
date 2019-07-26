using UnityEngine;
using System.Collections;

public class PlayerControllerSinglePlayer : MonoBehaviour
{
    CharacterController Player;
    

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    void Update()
    {

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

    }


}
