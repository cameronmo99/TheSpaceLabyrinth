using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{

    public int KeyCardNumber;
    public DoorControl DoorControl;



    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            Destroy(this.gameObject);

        }
    }

    public void OnDestroy()
    {
        DoorControl = GameObject.FindGameObjectWithTag("DoorControl").GetComponent<DoorControl>();
        DoorControl.Doors[KeyCardNumber] = true;
    }

}
