using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float Speed = 8;
	public float JumpSpeed = 20;
	public bool Player1;
	public float GroundLevel = -3;
	
	private Rigidbody2D _rb2D;
	private float _inputMove;
	private float _inputJump;
	
	private void Start ()
	{
		_rb2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{	
		_inputMove = Input.GetAxis(Player1 ? "P1Move" : "P2Move");
		_inputJump = _rb2D.velocity.y;

		if (Input.GetButtonDown(Player1 ? "P1Jump" : "P2Jump")&&Grounded()) 
			_inputJump = JumpSpeed;
	}

	private void FixedUpdate()
	{
		_rb2D.velocity = new Vector2(_inputMove * Speed, _inputJump);
	}
	
	public bool Walking()
	{
		return Math.Abs(_inputMove) > 0;
	}

	public bool Grounded()
	{
		return transform.position.y < GroundLevel;
	}
}



