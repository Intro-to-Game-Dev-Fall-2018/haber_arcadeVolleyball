using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

	private float _move;
	private float _jumpAxis;
	private bool _jump;
	private Rigidbody2D _rb2D;

	private void Start ()
	{
		_rb2D = GetComponent<Rigidbody2D>();
		_jump = false;
	}
	
	private void FixedUpdate () 
	{
		_jumpAxis = _rb2D.velocity.y;

		if (_jump)
		{
			_jumpAxis = Settings.s.PlayerJumpSpeed;
			_jump = false;
		}
		
		_rb2D.velocity = new Vector2(_move * Settings.s.PlayerSpeed, _jumpAxis);
	}

	public void Move(float input)
	{
		_move = Mathf.Clamp(input,-1,1);
	}
	
	public void Jump()
	{
		if (Grounded()) _jump = true;
	}
	
	public bool Grounded()
	{
		return transform.position.y < Settings.s.GroundLevel;
	}
	
	public bool Walking()
	{
		return _move * _move > 0f;
	}
}
