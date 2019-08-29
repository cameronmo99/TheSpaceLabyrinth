using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    public bool DoorTriggerBool;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            DoorTriggerBool = true;
        }

        if (other.tag == "AI")
        {
            DoorTriggerBool = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player1")
        {
            DoorTriggerBool = false;
        }

        if (other.tag == "AI")
        {
            DoorTriggerBool = false;
        }

    }
}