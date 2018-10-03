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
	private Random _rand;
	
	private void Start () {
		_motor = GetComponent<PlayerMotor>();
		_defaultPosition = transform.position;
		_rand = new Random();
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

		if (_ball.position.y <= -1.4f)
		{
			_motor.Jump();
			_direction = _rand.Next(1) == 0 ? 1 : -1;

		}
		
		_direction = Mathf.Clamp(_direction,-1f,1f);
		_motor.Move(_direction);
		
	}
	
}
