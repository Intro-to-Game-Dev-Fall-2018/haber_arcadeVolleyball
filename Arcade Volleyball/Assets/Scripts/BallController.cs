﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
	//public variables
	public Transform P1;
	public Transform P2;
	public float BallSpeed = 8;
	public GameManager Game;

	//private variables
	private Rigidbody2D _rb2D;
	private GameObject _lastCollision;
	private int _hitCount1;
	private int _hitCount2;
	private float _ballSpeed;

	//constants
	private const float _gravity = -.0001f;
	private const float _ballAcceleration = .001f;

	private void Start ()
	{
		_rb2D = GetComponent<Rigidbody2D>();
		Reset();
	}

	public void Reset()
	{
		Serve(P1.position);
	}

	public bool isStill()
	{
		return _rb2D.velocity.magnitude == 0;
	}


	private void FixedUpdate()
	{
		if (isStill()) return;
		_ballSpeed += _ballAcceleration;
		_rb2D.velocity = _rb2D.velocity.normalized *  _ballSpeed;
		_rb2D.AddForce(new Vector2(0,_gravity));
		
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player1Floor"))
		{
			Game.P2Score();
		}
		else if (other.gameObject.CompareTag("Player2Floor"))
		{
			Game.P1Score();
		}
		else if (other.gameObject == _lastCollision)
		{
			
		}
		else if (other.gameObject.CompareTag("Player1"))
		{
			if ((_hitCount1 += 1) >= 4) Game.P2Score();
			_hitCount2 = 0;
		}
		else if (other.gameObject.CompareTag("Player2"))
		{
			if ((_hitCount2 += 1) >= 4) Game.P1Score();
			_hitCount1 = 0;
		}

		_lastCollision = other.gameObject;
	}

	public void Serve(Vector3 here)
	{
		_hitCount1 = _hitCount2 = 0;
		transform.position = here;
		_rb2D.velocity = new Vector2(0,0);
		_rb2D.angularVelocity = 0;
		_ballSpeed = BallSpeed;
	}
}
