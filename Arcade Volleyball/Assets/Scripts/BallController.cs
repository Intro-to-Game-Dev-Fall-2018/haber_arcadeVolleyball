using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

	public GameFlowManager Game;
	public Transform P1;
	public Transform P2;
	public float ServeSpeed = 8;
	public float ballSpeed = 8;

	private Rigidbody2D _rb2D;
	
	void Start ()
	{
		_rb2D = GetComponent<Rigidbody2D>();
		Serve(P1.position);
	}

	private void LateUpdate()
	{
		_rb2D.velocity = _rb2D.velocity.normalized *  ballSpeed;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player1Floor"))
		{
			Game.P2Score();
			Serve(P2.position);
		} 
		else if (other.gameObject.CompareTag("Player2Floor"))
		{
			Game.P1Score();
			Serve(P1.position);
		}
	}

	private void Serve(Vector3 position)
	{
		transform.position = position + new Vector3(0,1.5f,0);
		_rb2D.velocity = new Vector2(0,ServeSpeed);
		_rb2D.rotation = 0;
	}
}
