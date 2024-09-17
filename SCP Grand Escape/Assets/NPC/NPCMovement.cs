using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private CharacterController _controller;
    private float _gravity = 0.06f;
    private Vector3 _velocity;

    void Start()
    {
        
    }


    void Update()
    {
        Move();
        DoGravity();
    }


    private void Move()
    {
        float horisontalInput = 2.0f;
        float verticalInput = 0f;
        Vector3 moveDeraction = transform.forward * verticalInput + transform.right * horisontalInput;
        moveDeraction.y -= 9.81f * Time.deltaTime;
       // _controller.Move(moveDeraction * _speed * Time.deltaTime);
    }

    private void DoGravity()
    {
        _velocity.y -= 0.06f;
        if (_velocity.y < -8.0f)
        {
            _velocity.y = -8f;
        }

        _controller.Move(_velocity * Time.deltaTime);
    }

}
