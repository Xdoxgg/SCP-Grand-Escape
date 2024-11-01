using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class MovingControl : MonoBehaviour
{
    private float _moveSpeed = 3f;
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private Playerstats _stats;

    private Vector3 _velocity;
    private bool _run;


    void Avake()
    {
        _controller = GetComponent<CharacterController>();
    }

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update()
    {
		
	
		if (Input.GetKey(KeyCode.Space) && _controller.isGrounded)
        {
            Jump();
        }
  
        if (Input.GetKey(KeyCode.LeftControl) && _controller.isGrounded)
        {
          
        }

        if (_stats.ReadyToRun && Input.GetKey(KeyCode.LeftShift) && _controller.isGrounded && !Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            _moveSpeed = 6.0f; 
            _run = true;
        }
        else
        {
            _moveSpeed = 3.0f;
            _run=false;
        }
        
        float horisontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDeraction = transform.forward * verticalInput + transform.right * horisontalInput;
        moveDeraction.y -= 9.81f * Time.deltaTime;
        _controller.Move(moveDeraction * _moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Gravity();
    }

    private void Jump()
    {
        _velocity.y = 2f;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void Gravity()
    {
        _velocity.y -= 0.06f;
        if (_velocity.y < -8.0f)
        {
            _velocity.y = -8f;
        }

        _controller.Move(_velocity * Time.deltaTime);
    }

    public bool Runing
    {
        get { return _run; }
        set { _run = value; }
    }
  
}