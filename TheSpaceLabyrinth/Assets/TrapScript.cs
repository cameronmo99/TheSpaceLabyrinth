using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : BaseTrapClass
{


    public bool BlindTrap;
    public bool SlowdownTrap;


    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1" && PlayerHasEntered == false)
        {

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

}
