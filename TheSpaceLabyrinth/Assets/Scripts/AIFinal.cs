using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIFinal : MonoBehaviour
{




    public Transform Player;

    public GameObject PlayerGameObject;

    public Rigidbody AI_Rigidbody;

    public float PatrolDistance;

    public bool Sentry;

    public float AttackDistance = 1.5f;

    public float ChaseDistance;

    public float AI_Speed;



    public int NumberOfWaypoints;

    public int FirstWaypointNumber;

    public int lastWaypointNumber;

    public Scene CurrentScene;


    public GameObject AI;

    public Transform[] Waypoints;

    public GameObject Temp;

    public int WhichCube;

    public Transform CubeTransform;

    public float SpeedLimit;

    public float SpeedLimitAtWaypoint;

    public Light SearchLight;

    public float SentryAngle;

    public Transform SentryPoint;

    public float SentryDistance;

    public bool AtSentryPoint;






    public enum State
    {
        Attack,
        Patrol,
        Chase,
        Sentry,
    }

    State ActiveState;


    public void setActiveState(State State)
    {
        ActiveState = State;
    }





    public void Start()
    {
        setActiveState(State.Patrol);

        AI_Rigidbody = GetComponent<Rigidbody>();

        CurrentScene = SceneManager.GetActiveScene();

        SearchLight.color = Color.green;




    }



    public void Update()
    {


        Debug.Log(ActiveState);
        switch (ActiveState)
        {
            //Attack State
            case State.Attack:


                SceneManager.LoadScene("Lose"); //Change to UI
                setActiveState(State.Patrol);

                break;



            //Patrol Staet
            case State.Patrol:

                if (Sentry == true)
                {
                    setActiveState(State.Sentry);
                }

                //Ai movement
                AI_Rigidbody.AddForce((transform.forward * AI_Speed));



                /*if (WhichCube == TheAIScript.NumberOfPartolPoints)
                {
                    WhichCube = 0;
                }

                transform.LookAt(TheAIScript.PartolPoints[WhichCube]);


                if (Vector3.Distance(PartolPoints[WhichCube].position, transform.position) <= PatrolDistance)
                {
                    WhichCube++;
                }


                //If the player is a certain distance it will switch the state to chase
                if (Vector3.Distance(Player.position, transform.position/*this*//*) <= ChaseDistance)
                {
                    setActiveState(State.Chase);
                }*/

                SearchLight.color = Color.green;

                if (NumberOfWaypoints == WhichCube)
                {
                    WhichCube = 0;
                }

                transform.LookAt(Waypoints[WhichCube]);

                if (Vector3.Distance(Waypoints[WhichCube].position, transform.position) <= PatrolDistance)
                {
                    WhichCube++;
                }

                if (Vector3.Distance(transform.position, Player.position) <= AttackDistance)
                {
                    setActiveState(State.Chase);
                }


                break;


            /*case State.Wander:



                //Ai movement
                AI_Rigidbody.AddForce((transform.forward * AI_Speed));


                if (Vector3.Distance(PartolPoints[WhichCube].position, transform.position) <= PatrolDistance)
                {
                    WhichCube = Random.Range(0, NumberOfPartolPoints);
                }

                transform.LookAt(TheAIScript.PartolPoints[WhichCube]);

                if (Vector3.Distance(Player.position, transform.position/*this*//*) <= ChaseDistance)
                {
                    setActiveState(State.Chase);
                }

                break;*/




            //Chase State
            case State.Chase:


                //Ai Direction
                transform.LookAt(Player);

                //Ai movement
                AI_Rigidbody.AddForce((transform.forward * AI_Speed));

                SearchLight.color = Color.red;

                //If the player is a certain distance it will switch the state to attack
                if (Vector3.Distance((Player.position), transform.position) <= AttackDistance)
                {
                    setActiveState(State.Attack);
                }
                if (Vector3.Distance((Player.position), transform.position) > ChaseDistance)
                {
                    setActiveState(State.Patrol);
                }


                break;


            case State.Sentry:


                SearchLight.color = Color.yellow;
                if (Vector3.Distance(SentryPoint.position, transform.position/*this*/) > SentryDistance)
                {
                    //if (AtSentryPoint == false)
                   // {
                        transform.LookAt(SentryPoint);
                        AI_Rigidbody.AddForce((transform.forward * AI_Speed));
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, SentryAngle, 0);
                    AI_Rigidbody.velocity = new Vector3(0, 0, 0);
                    }
               // }

                if (Vector3.Distance(Player.position, transform.position/*this*/) <= ChaseDistance)
                {
                    setActiveState(State.Chase);
                }


                break;
        }
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(Waypoints[WhichCube].position, transform.position) <= SpeedLimitAtWaypoint)
        {
            SpeedLimit = 0.5f;
        }
        else
        {
            SpeedLimit = 1.5f;
        }


        if (AI_Rigidbody.velocity.magnitude > SpeedLimit)
        {
            AI_Rigidbody.velocity = AI_Rigidbody.velocity.normalized * SpeedLimit;
        }
    }


}
