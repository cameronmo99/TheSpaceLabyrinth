using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : BaseTrapClass
{


    public bool BlindTrap;
    public bool SlowdownTrap;
    public float NormalSpeed;


    void Start()
    {
        //Gets the Players Speed
        PlayerScript = Player.GetComponent<PlayerScriptV2>();
        NormalSpeed = PlayerScript.speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1" && PlayerHasEntered == false)
        {
            //Checks which trap it is then starts the coroutine
            PlayerHasEntered = true;
            if (BlindTrap == true)
            {
                StartCoroutine("TorchFlicker");
            }
            if (SlowdownTrap == true)
            {
                StartCoroutine("SlowDown");
            }
        }


    }

    IEnumerator SlowDown()
    {
        //Slows the Player for 30 seconds
        PlayerScript = Player.GetComponent<PlayerScriptV2>();
        PlayerScript.speed = Speed;
        yield return new WaitForSeconds(30f);
        PlayerScript.speed = NormalSpeed;
    }

}
