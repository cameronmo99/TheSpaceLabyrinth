using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AI : MonoBehaviour
{

    public Transform Player;

    public GameObject PlayerGameObject;

    public Rigidbody AI_Rigidbody;

    //The Potrol Points and Distance
    public Transform Patrol_1;

    public Transform Patrol_2;

    public Transform Patrol_3;

    public Transform Patrol_4;

    public float PatrolDistance;

    public float AttackDistance;

    public Transform WhichCube;

    public float SpeedLimit;

    public float SpeedLimitAtWaypoint;

    public Scene CurrentScene;



    public float AI_Speed;

    public Light SearchLight;


    //Sets initial start state as patrol
    public void Start()
    {

        CurrentScene = SceneManager.GetActiveScene();
        AI_Rigidbody = GetComponent<Rigidbody>();
    }


    //The Switch Case with the states
    public void Update()
    {


                AI_Rigidbody.AddForce((transform.forward * AI_Speed));

                //Where the Ai is heading
                transform.LookAt(WhichCube);

        if (Vector3.Distance(transform.position, Player.position) <= AttackDistance)
        {
            transform.LookAt(Player);
        }
        else
        {

            //Patrol Point Switching
            if (Vector3.Distance(Patrol_1.position, transform.position) <= PatrolDistance)
            {
                WhichCube = Patrol_2.transform;
            }

            if (Vector3.Distance(Patrol_2.position, transform.position) <= PatrolDistance)
            {
                WhichCube = Patrol_3.transform;
            }

            if (Vector3.Distance(Patrol_3.position, transform.position) <= PatrolDistance)
            {
                WhichCube = Patrol_4.transform;
            }

            if (Vector3.Distance(Patrol_4.position, transform.position) <= PatrolDistance)
            {
                WhichCube = Patrol_1.transform;
            }
        }


        //Ai Direction


                //Ai movement
                AI_Rigidbody.AddForce((transform.forward * AI_Speed));

        //If the player is a certain distance it will switch the state to attack

        if (Vector3.Distance(transform.position, Player.position) <= AttackDistance)
        {
            SearchLight.color = Color.red;
        }
        else
        {
            SearchLight.color = Color.green;
        }

        if (Vector3.Distance(transform.position, Player.position) <= 1.5)
        {
            SceneManager.LoadScene(CurrentScene.name);
        }




    }



    void FixedUpdate()
    {
        if(Vector3.Distance(WhichCube.position,transform.position) <= SpeedLimitAtWaypoint)
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
