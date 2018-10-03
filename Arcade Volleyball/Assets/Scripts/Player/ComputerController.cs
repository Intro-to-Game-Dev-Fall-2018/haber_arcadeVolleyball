using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ComputerController : MonoBehaviour
{

	[SerializeField] private Rigidbody2D _ball;
	
	private PlayerMotor _motor;
	private float _direction;
	private Vector3 _defaultPosition;
	
	private void Start () {
		_motor = GetComponent<PlayerMotor>();
		_defaultPosition = transform.position;
	}
	
	private void Update ()
	{
		if (_ball.position.x <= 0)
		{
			_direction = Mathf.Clamp(_defaultPosition.x - transform.position.x,-1f,1f);
			_motor.Move(_direction);
			return;
		}

		_direction = _ball.position.x - transform.position.x;

		if (_ball.position.y <= -1.5f)
		{
			_motor.Jump();
			_direction = transform.position.x > 1.5 ? 1 : -1;

		}
		
		_direction = Mathf.Clamp(_direction,-1f,1f);
		_motor.Move(_direction);
		
	}
	
}
