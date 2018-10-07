using System.Collections;
using UnityEngine;

public enum STATE
{
	RESET = 0,
	PLAY1 = 1,
	PLAY2 = 2,
	SERVE = 4,
	OFF = 5
}

public class ComputerController : MonoBehaviour
{

	[SerializeField] private Rigidbody2D _ball;
	
	private PlayerMotor _motor;
	private Vector3 _defaultPosition;
	private STATE _state;

	
	public void activate()
	{
		changeState(STATE.OFF);
	}
	
	private void Start () {
		_motor = GetComponent<PlayerMotor>();
		_defaultPosition = transform.position;
		activate();
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
				case STATE.PLAY1:
					StartCoroutine(play1());
					return;
				case STATE.PLAY2:
					StartCoroutine(Play2());
					return;
				case STATE.SERVE:
					StartCoroutine(serve());
					return;
				case STATE.OFF:
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
			changeState(STATE.PLAY1);
	}

	private IEnumerator play1()
	{
		yield return new WaitForSeconds(.5f);
		while (_state == STATE.PLAY1)
		{
			_motor.Move(ballX()+ _ball.position.x > 4f ? -.5f: .5f);

			if (_ball.position.y <= -1.5f)
			{
				_motor.Move(_ball.position.x > 4f ? 1f: -1f);
				if (_ball.velocity.y > 1f) _motor.Jump();
			}
			
			yield return null;
		}
	}

	private IEnumerator Play2()
	{
		yield return new WaitForSeconds(.5f);
		while (_state == STATE.PLAY1)
		{
			_motor.Move(ballX()+ _ball.position.x > 4f ? -.5f: .5f);

			if (_ball.position.y <= -1.5f)
			{
				_motor.Move(_ball.position.x > 4f ? 1f: -1f);
				if (_ball.velocity.y > 1f) _motor.Jump();
			}
			
			yield return null;
		}
	}
	
	private IEnumerator serve()
	{
		yield return new WaitForSeconds(Settings.s.WaitBeforeServe);
		_motor.Move(-1f);
		yield return new WaitForSeconds(.1f);
		_motor.Move(-1f);
		_motor.Jump();
	}

	private IEnumerator goHome()
	{
		while (_state == STATE.RESET)
		{
			_motor.Move(distanceHome());
			if (distanceHome() == 0f)
				yield break;
			yield return null;
		}
		_motor.Move(0f);
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
