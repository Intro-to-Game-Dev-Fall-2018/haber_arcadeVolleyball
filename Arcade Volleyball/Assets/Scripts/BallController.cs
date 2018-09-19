using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

	public Transform P1;
	public Transform P2;
	public float BallSpeed = 8;
	public float BallAcceleration = .001f;
	public GameFlowManager Game;

	private Rigidbody2D _rb2D;
	private int _hitCount1;
	private int _hitCount2;
	private GameObject _lastCollision;
	private float _ballSpeed;

	private void Start ()
	{
		Game = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
		_hitCount1 = _hitCount2 = 0;
		_rb2D = GetComponent<Rigidbody2D>();
		Serve(P1.position);
	}

	private void LateUpdate()
	{
		_rb2D.velocity = _rb2D.velocity.normalized *  _ballSpeed;
	}

	private void FixedUpdate()
	{
		if (_rb2D.velocity.magnitude==0) return;
		_ballSpeed += BallAcceleration;
		
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
