using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseAIScript : MonoBehaviour
{
    public float Speed;
    public Transform Waypoint;
    public Rigidbody AIGameObject;
    public float Distance;

    public int WaypointRandomNumber;
    public int WhichWaypoint;
    public int WaypointAmount;


    public float RaycastDistance;
    public RaycastHit HitForward;
    public RaycastHit HitLeft;
    public RaycastHit HitRight;
    public RaycastHit HitBackwards;

    public GameObject WaypointForward;
    public GameObject WaypointLeft;
    public GameObject WaypointRight;
    public GameObject WaypointBackwards;
    public GameObject WaypointGameObject;
    public GameObject CurrentWaypintGameobject;
    public Transform CurrentWaypoint;

    public List<GameObject> WaypointsList;
    //  List<GameObject> WaypointsList = new List<GameObject>();
    public Vector3 ForwardVector;
    public Vector3 LeftVector;
    public Vector3 RightVector;
    public Vector3 BackVector;

    public GameObject BlacklistedWaypoint;

    public int ListCount;


    public bool player1Near = false;
    public Transform Player1Transform;
    public GameObject Player1Gameobject;

    public bool player2Near = false;
    public Transform Player2Transform;
    public GameObject Player2Gameobject;

    public float PlayerDistance;



    void Start()
    {


        //WaypointAmount = WaypointsList.Count;
        //   List<GameObject> WaypointsList = new List<GameObject>();
        // ForwardVector = new Vector3(0, 0, RaycastDistance);
        // LeftVector = new Vector3(-RaycastDistance, 0, 0);
        // RightVector = new Vector3(RaycastDistance, 0, 0);
        // BackVector = new Vector3(0, 0, -RaycastDistance);
    }

    // Update is called once per frame
    void Update()
    {

        //Makes the Enemy look at the Waypoint
        //transform.LookAt(Waypoint);

        //If the Distance it more than 0 the Enemy will move towards the Player
        /* if (Vector3.Distance(transform.position, Waypoint.position) >= Distance)
         {
             transform.position += transform.forward * Speed * Time.deltaTime;
         } */
    }

    public void GetNewWaypoint()
    {
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);

        // if (Physics.Raycast(transform.position, fwd, 10, out hit))
        //      if (Physics.Raycast(transform.position, ForwardVector, out HitForward, RaycastDistance))

        //Checks is a Player is Near
        if (Vector3.Distance(transform.position, Player1Transform.position) <= PlayerDistance)
        {
            player1Near = true;
        }
        else
        {
            player1Near = false;
        }

        if (Vector3.Distance(transform.position, Player2Transform.position) <= PlayerDistance)
        {
            player2Near = true;
        }
        else
        {
            player2Near = false;
        }

        //Gets Waypoints and adds them to a List
        if (Physics.Raycast(transform.position, Vector3.forward, out HitForward, RaycastDistance))
        {

            if (HitForward.transform.tag == "Waypoint")
            {
                WaypointsList.Add(HitForward.transform.gameObject);

            }

        }

        if (Physics.Raycast(transform.position, Vector3.left, out HitLeft, RaycastDistance))
        {

            if (HitLeft.transform.tag == "Waypoint")
            {
                WaypointsList.Add(HitLeft.transform.gameObject);
            }

        }

        if (Physics.Raycast(transform.position, Vector3.right, out HitRight, RaycastDistance))
        {

            if (HitRight.transform.tag == "Waypoint")
            {
                WaypointsList.Add(HitRight.transform.gameObject);
            }

        }

        if (Physics.Raycast(transform.position, Vector3.back, out HitBackwards, RaycastDistance))
        {

            if (HitBackwards.transform.tag == "Waypoint")
            {
                WaypointsList.Add(HitBackwards.transform.gameObject);
            }
        }
    }

    public void ClearWaypointsList()
    {
        //Clears the Waypoint List
        WaypointsList.Clear();
    }

    public void ChooseWaypoint()
    {
        ClearWaypointsList();
        GetNewWaypoint();
        ListCount = WaypointsList.Count;

        //Gets a Random Waypoint from the list
        WaypointRandomNumber = Random.Range(0, ListCount);

        WaypointGameObject = WaypointsList[WaypointRandomNumber];

        //  if (WaypointGameObject == null)
        //  {
        //      Debug.Log("test");
        //      ChooseWaypoint();
        //  }

        //Gets the Waypoint Transform 
        Waypoint = WaypointGameObject.transform;
        BlacklistedWaypoint = WaypointGameObject;


        // if (BlacklistedWaypoint == WaypointGameObject)
        // {
        //     if (ListCount > 1)
        //     {
        //         ChooseWaypoint();
        //     }
        //
        //}


    }

    public void GoToSetTarget()
    {
        CurrentWaypintGameobject = WaypointsList[WhichWaypoint];
        CurrentWaypoint = CurrentWaypintGameobject.transform;
        if (WhichWaypoint == WaypointAmount)
        {
            WhichWaypoint = 0;
        }
        //UpdateWaypoints();
        if (Vector3.Distance(CurrentWaypoint.position, transform.position) <= Distance)
        {
            WhichWaypoint++;
        }

        if (player1Near == true)
        {
            transform.LookAt(Player1Transform);
            transform.position += transform.forward * (Speed * 2) * Time.deltaTime;
        }
        else
        {
            GoToSetWaypoint();
        }

        if (player2Near == true)
        {
            transform.LookAt(Player2Transform);
            transform.position += transform.forward * (Speed * 2) * Time.deltaTime;
        }
        else
        {
            GoToSetWaypoint();
        }

    }

    public void GoToTarget()
    {
        //If the Player is Near will Attack the Player else will go to Waypoint
        if (player1Near == true)
        {
            transform.LookAt(Player1Transform);
            transform.position += transform.forward * (Speed * 2) * Time.deltaTime;
        }
        else
        {
            GoToWaypoint();
        }

        if (player2Near == true)
        {
            transform.LookAt(Player2Transform);
            transform.position += transform.forward * (Speed * 2) * Time.deltaTime;
        }
        else
        {
            GoToWaypoint();
        }
    }
    public void GoToWaypoint()
    {
        //Looks and Goes to Waypoint
        transform.LookAt(Waypoint);
        if (Vector3.Distance(transform.position, Waypoint.position) >= Distance)
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
        if (Vector3.Distance(transform.position, Waypoint.position) <= Distance)
        {
            //ClearWaypointsList();
            ChooseWaypoint();
        }

    }
    public void GoToSetWaypoint()
    {
        //Looks and Goes to Waypoint
        transform.LookAt(Waypoint);
        if (Vector3.Distance(transform.position, CurrentWaypoint.position) >= Distance)
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
        /*if (Vector3.Distance(transform.position, CurrentWaypoint.position) <= Distance)
        {
            //ClearWaypointsList();
            ChooseWaypoint();
        }*/

    }
    //public void GetPlayers()
    //{
    //    Player1Gameobject = GameObject.FindGameObjectWithTag("Player1");
    //    Player1Transform = Player1Gameobject.transform;
    //    Player2Gameobject = GameObject.FindGameObjectWithTag("Player2");
    //    Player1Transform = Player1Gameobject.transform;
    //}
    public void UpdateWaypoints()
    {
        WaypointAmount = WaypointsList.Count;



    }

}



