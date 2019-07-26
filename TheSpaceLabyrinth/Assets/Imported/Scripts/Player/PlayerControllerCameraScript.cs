using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCameraScript : MonoBehaviour
{
    public Camera Camera;

    public float minimumX = -60f;
    public float maximumX = 60f;
    public float minimumY = -360f;
    public float maximumY = 360f;

    public float SensitivityX = 15f;
    public float SensitivityY = 15f;

    public float RotationX = 0f;
    public float RotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        RotationY += Input.GetAxis("Mouse X") * SensitivityY;
        RotationX += Input.GetAxis("Mouse Y") * SensitivityX;

        RotationX = Mathf.Clamp(RotationX, minimumX, maximumX);

        transform.localEulerAngles = new Vector3(0, RotationY, 0);

        Camera.transform.localEulerAngles = new Vector3(-RotationX, RotationY, 0);
    }

} 
