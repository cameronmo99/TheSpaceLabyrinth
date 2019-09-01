using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardDoor : MonoBehaviour
{

    public int DoorNumber;

    public bool DoorOpening;
    public bool Trigger;

    public float OpenPosition;
    public float ClosedPosition;
    public float OpenPositionAdjuster;
    public float CurrentDoorPosition;
    public float DoorSpeed;

    public DoorTrigger ParentTrigger;

    public DoorControl DoorControl;






    void Start()
    {
        OpenPositionAdjuster = 1f;
        DoorSpeed = 4f;
        ParentTrigger = GetComponentInParent<DoorTrigger>();
        DoorControl = GameObject.FindGameObjectWithTag("DoorControl").GetComponent<DoorControl>();
        //DoorControlTemp = GetComponent<DoorControl>(DoorControl);
        ClosedPosition = gameObject.transform.localPosition.x;
        //ClosedPosition = Vector3.Distance(OpenPosition, ;
        //ClosedPosition = Vector3(0, 0, 0);
        OpenPosition = ClosedPosition + OpenPositionAdjuster;
        //ClosedPosition = OpenPosition + Vector3(0, 0, 4);
        //OpenPosition = ClosedPosition + Vector3.Distance(0, 0, 4f);
    }


    /*void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CanOpen = true;
            DoorOpening = true;
            Debug.Log("open");
        }

    }
    void OnTriggerExit(Collider other)
        {
            CanOpen = false;
            DoorOpening = false;
        }*/

    void Update()
    {

        //Open the Door
        if (ParentTrigger.DoorTriggerBool == true)
        {
             if (DoorControl.Doors[DoorNumber] == true)
            {
                DoorOpening = true;
                CurrentDoorPosition = gameObject.transform.localPosition.x;

                if (DoorOpening == true && CurrentDoorPosition < OpenPosition)
                {
                    gameObject.transform.Translate(Vector3.right * Time.deltaTime * DoorSpeed);
                }
            }
        }

        //Closes the Door
        if (ParentTrigger.DoorTriggerBool == false)
        {
            DoorOpening = false;

            CurrentDoorPosition = gameObject.transform.localPosition.x;
            if (DoorOpening == false && CurrentDoorPosition > ClosedPosition)
            {
                gameObject.transform.Translate(Vector3.left * Time.deltaTime * DoorSpeed);
            }
        }
    }







































    /*public bool OpenDoor;
    public bool CloseDoor;

    public float speed = 3;
    public float DoorOpenPosition = 8.5f;
    public float DoorClosedPosition = 4f;

    public float CurrentPosition;

    public Transform door;
    public Transform open;
    public Transform closed;



    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            OpenDoor = true;
            CloseDoor = false;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            OpenDoor = false;
            CloseDoor = true;
        }

    }


    void Update()
    {
        Vector3 DoorOpen = new Vector3(0, open.transform.position.y, 0);
        Vector3 DoorClosed = new Vector3(0, closed.transform.position.y, 0);
        Vector3 DoorMoving = new Vector3(0, door.transform.position.y, 0);

        if (opening == true)
            transform.Translate(0, speed * Time.deltaTime, 0);

        if (DoorMoving.y < DoorOpen.y)
        {
            opening = false;
            closing = true;
            door.transform.position = new Vector3(door.transform.position.x, open.transform.position.y, door.transform.position.z);
        }

        if (closing == true)
            transform.Translate(0, Cspeed * Time.deltaTime, 0);

        if (DoorMoving.y > DoorClosed.y)
        {
            closing = false;
            door.transform.position = new Vector3(door.transform.position.x, closed.transform.position.y, door.transform.position.z);
        }*/

}


