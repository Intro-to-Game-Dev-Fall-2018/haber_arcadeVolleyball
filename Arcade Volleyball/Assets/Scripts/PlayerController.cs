using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private float Speed = 8;
	[SerializeField] private float JumpSpeed = 20;
	[SerializeField] private bool Player1;
	[SerializeField] private float GroundLevel = -3;
	
	private Rigidbody2D _rb2D;
	private float _inputMove;
	private float _inputJump;
	private string _moveAxis;
	private string _jumpAxis;
	private Vector3 _defaultPosition;
	
	private void Start ()
	{
		_rb2D = GetComponent<Rigidbody2D>();
		_moveAxis = Player1 ? "P1Move" : "P2Move";
		_jumpAxis = Player1 ? "P1Jump" : "P2Jump";
		_defaultPosition = transform.position;
	}

	private void FixedUpdate()
	{
		_inputMove = Input.GetAxis(_moveAxis);
		_inputJump = _rb2D.velocity.y;

		if (Input.GetButtonDown(_jumpAxis) && Grounded()) 
			_inputJump = JumpSpeed;
		
		_rb2D.velocity = new Vector2(_inputMove * Speed, _inputJump);
	}
	
	public void Reset()
	{
		transform.position = _defaultPosition;
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



