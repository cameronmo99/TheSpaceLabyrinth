using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : BaseAIScript
{
    public float TestAISpeed;

    void Start()
    {
        Speed = TestAISpeed;
        //GetPlayers();
        GetNewWaypoint();
        ChooseWaypoint();
    }

    void Update()
    {
        GoToTarget();
        
    }
}
