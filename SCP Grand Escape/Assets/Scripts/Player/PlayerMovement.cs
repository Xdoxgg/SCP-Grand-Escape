using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingControl : MonoBehaviour
{
    private float _moveSpeed = 5.0f;


    private CharacterController _controller;
    [SerializeField]
    private Playerstats _stats;


    void Start()
    {
        _controller = GetComponent<CharacterController>();//если я правильно помю это создание кортежа из параметров контроля
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //бег
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl) && true)
        {

        }


        float horisontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 moveDeraction = transform.forward * verticalInput + transform.right * horisontalInput;


        moveDeraction.y -= 9.81f * Time.deltaTime;

        _controller.Move(moveDeraction * _moveSpeed * Time.deltaTime);
    }
}
