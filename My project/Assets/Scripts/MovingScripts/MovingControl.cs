using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingControl : MonoBehaviour
{
    public float moveSpeed = 5.0f;


    private CharacterController _controller;

    
    void Start()
    {
        _controller = GetComponent<CharacterController>();//если я правильно помю это создание кортежа из параметров контроля
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float horisontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 moveDeraction = transform.forward * verticalInput + transform.right * horisontalInput;


        moveDeraction.y -=9.81f*Time.deltaTime;

        _controller.Move(moveDeraction*moveSpeed*Time.deltaTime);
    }
}
