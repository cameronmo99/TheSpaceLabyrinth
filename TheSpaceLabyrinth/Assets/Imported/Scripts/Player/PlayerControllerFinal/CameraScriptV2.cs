using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptV2 : MonoBehaviour
{

    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public GameObject Player;
    private Vector2 mouseLook;
    private Vector2 Smoothing;

    // Use this for initialization
    void Start()
    {
        Player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the Vector2 Data from the Mouse
        var Mouse = new Vector2(Input.GetAxisRaw("Mouse X"), 0/*Input.GetAxisRaw("Mouse Y")*/);
        Mouse = Vector2.Scale(Mouse, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        //Smooths the Movement
        Smoothing.x = Mathf.Lerp(Smoothing.x, Mouse.x, 1f / smoothing);
        Smoothing.y = Mathf.Lerp(Smoothing.y, Mouse.y, 1f / smoothing);
        //Is added to the Camera
        mouseLook += Smoothing;

        //Moves the Camera
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Player.transform.up);

        if(this.transform.localRotation.x != 0)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        if (this.transform.rotation.x < 0)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}