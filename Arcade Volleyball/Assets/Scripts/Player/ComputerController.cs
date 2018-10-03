using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{

	[SerializeField] private Rigidbody2D _ball;
	
	private PlayerMotor _motor;
	private float _direction;
	
	private void Start () {
		_motor = GetComponent<PlayerMotor>();
	}
	
	private void Update ()
	{
		if (_ball.position.x < 0) return;
		_direction = Mathf.Clamp(_ball.position.x - transform.position.x,-1f,1f);
		
		if (_ball.position.y <= -1.4f) _motor.Jump();
		_motor.Move(_direction);
	}
}
