using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{


    public int NumberofDoors;
    public bool[] Doors;


    // Start is called before the first frame update
    void Start()
    {
        Doors = new bool[NumberofDoors];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
