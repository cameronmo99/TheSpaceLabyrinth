using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTestScript : MonoBehaviour

{
    public float RaycastDistance;
    RaycastHit hitfwd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        // if (Physics.Raycast(transform.position, fwd, 10, out hit))
        if (Physics.Raycast(transform.position, Vector3.forward, out hitfwd, RaycastDistance))
        {
            Debug.Log("1");
            if (hitfwd.transform.tag == "Waypoint")
            print("There is something in front of the object!");
        }

        Debug.DrawRay(transform.position, fwd, Color.green);
    }
}
