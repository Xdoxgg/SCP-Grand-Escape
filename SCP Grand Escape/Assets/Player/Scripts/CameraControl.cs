using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public float mouseSensetive = 2.0f;
    public float maxYAngle = 80.0f;
    private float _rotationX = 0.0f;


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");


        transform.parent.Rotate(Vector3.up * mouseX * mouseSensetive);


        _rotationX -= mouseY * mouseSensetive;
        _rotationX = Mathf.Clamp(_rotationX, -maxYAngle, maxYAngle);
        transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);

    }
}
