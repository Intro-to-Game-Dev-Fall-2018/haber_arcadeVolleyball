using System.Collections;
using UnityEngine;

public enum STATE
{
	RESET = 0,
	PLAY = 1,
	SERVE = 3
}

public class ComputerController : MonoBehaviour
{

	[SerializeField] private Rigidbody2D _ball;
	
	private PlayerMotor _motor;
	private Vector3 _defaultPosition;
	private STATE _state = STATE.RESET;

	
	private void Start () {
		_motor = GetComponent<PlayerMotor>();
		_defaultPosition = transform.position;
	}

	private void changeState(STATE newState)
	{
		if (_state == newState) return;
		
		StopAllCoroutines();
		_state = newState;

		switch (newState)
		{
				case STATE.RESET:
					StartCoroutine(goHome());
					return;
				case STATE.PLAY:
					StartCoroutine(play());
					return;
				case STATE.SERVE:
					StartCoroutine(serve());
					return;
				default:
					return;
		}

	}
	
	private void Update ()
	{
		if (_ball.position.x <= 0f)
			changeState(STATE.RESET);
		
		else if (_ball.velocity.magnitude == 0f)
			changeState(STATE.SERVE);
		
		else if (_ball.position.x > 0f) 
			changeState(STATE.PLAY);
	}

	private IEnumerator play()
	{
		while (_state == STATE.PLAY)
		{
			_motor.Move(ballX());
			
			if (_ball.position.y <= -1.5f)
				_motor.Jump();
			
			yield return null;
		}
	}

	private IEnumerator serve()
	{
		_motor.Move(-.4f);
		yield return new WaitForSeconds(1.3f);
		_motor.Move(-1f);
		yield return new WaitForEndOfFrame();
		_motor.Jump();
	}

	private IEnumerator goHome()
	{
		while (_state == STATE.RESET)
		{
			_motor.Move(distanceHome());

			if (distanceHome() == 0f)
			{
				_motor.Move(0f);
				yield break;
			}
			
			yield return null;
		}
	}

	private float ballX()
	{
		return _ball.position.x - transform.position.x;
	}

	private float distanceHome()
	{
		return _defaultPosition.x - transform.position.x;
	}
}
