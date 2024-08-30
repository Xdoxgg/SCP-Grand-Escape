using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class MovingControl : MonoBehaviour
{
    private float _moveSpeed = 3.0f;
    [SerializeField]
    private CharacterController _controller;
    private Playerstats _stats;
    private float _gravity = 2.0f;
    private Vector3 _velocity;
    private float _jumpStrenght = 2.0f;
    [SerializeField]
    private bool _isSeat;

    void Start()
    {
        _controller = GetComponent<CharacterController>();//если я правильно помю это создание кортежа из параметров контроля
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _stats=new Playerstats();
    }



    void Update()
    {
        //прыжок
        //Jump();
        if (Input.GetKey(KeyCode.Space) && _controller.isGrounded)
        {
            Jump();
        }
        //присесть
        if (Input.GetKey(KeyCode.LeftControl) && _controller.isGrounded)
        {
            _isSeat = !_isSeat;
            Seat();
        }
        //бег
        if (Input.GetKey(KeyCode.LeftShift) && _controller.isGrounded && !_isSeat && !Input.GetKey(KeyCode.LeftControl) && _stats.Stamina >= 30 && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            _moveSpeed = 6.0f;
        }
        else
        {
            _moveSpeed = 3.0f;
        }
        float horisontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDeraction = transform.forward * verticalInput + transform.right * horisontalInput;
        moveDeraction.y -= 9.81f * Time.deltaTime;
        _controller.Move(moveDeraction * _moveSpeed * Time.deltaTime);
    }


    private void FixedUpdate()
    {
        Gravity(_controller.isGrounded);
    }


    private void Gravity(bool isGrounded)
    {
        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        _velocity.y-=_gravity*Time.fixedDeltaTime;
        _controller.Move(_velocity* Time.fixedDeltaTime);
    }

    private void Jump()
    {
        _velocity.y = _jumpStrenght;
    }

    private void Seat()
    {
        if (_isSeat)
        {
            _controller.height = 1f;
        }
        else
        {
            _controller.height = 2f;
        }
    }
    

}
