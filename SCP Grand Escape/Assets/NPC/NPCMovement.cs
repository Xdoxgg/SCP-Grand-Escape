using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Properties;
using UnityEditor;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

	//private float _rotationX = 0.0f;
	[SerializeField]
    private CharacterController _controller;
	[SerializeField]
	private GameObject _player;
	private float _moveSpeed = 2f;
	private Vector3 _velocity;

	[SerializeField]
	private float val;

	void Avake()
	{
		_controller = GetComponent<CharacterController>();
	}



	private void FixedUpdate()
	{
		Gravity();
		Move(false);
	}


	private void Update()
	{
		transform.parent.Rotate(Vector3.up);
	}



	private void Move(bool viewPlayer)
	{
		float horisontalInput=0f;
		if (viewPlayer)
		{
			horisontalInput = 0f;
		}
		else
		{
			horisontalInput = (float)(int)Random.Range(-1,2);
		}
		val = horisontalInput;
		float verticalInput = 1f;
		Vector3 moveDeraction = transform.forward * verticalInput + transform.right * horisontalInput;
		moveDeraction.y -= 9.81f * Time.deltaTime;
		_controller.Move(moveDeraction * _moveSpeed * Time.deltaTime);
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
}
