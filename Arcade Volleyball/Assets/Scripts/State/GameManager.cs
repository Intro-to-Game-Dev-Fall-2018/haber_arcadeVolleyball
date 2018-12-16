using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header("Menu Objects")]
	[SerializeField] private AudioManager Audio;
	[SerializeField] private BallController Ball;
	[SerializeField] private SkinManagerV2 Skins;

	private GameState _gameState;
	
	private void Start ()
	{
		Reset();
	}
	
	private void Reset()
	{
		_gameState = new GameState();
		EventManager.i.onScore.Invoke(_gameState);
	}
	
	public void ResetGame()
	{
		Reset();
		Ball.Reset();
	}

	public void P1Score()
	{
		_gameState.P1score++;
		EventManager.i.onScore.Invoke(_gameState);

		StartCoroutine(_gameState.P1score >= Settings.s.WinScore ? win() : Score(Ball.P1.position));
	}
	
	public void P2Score()
	{
		_gameState.P2score++;
		EventManager.i.onScore.Invoke(_gameState);
		StartCoroutine(_gameState.P2score >= Settings.s.WinScore ? win() : Score(Ball.P2.position));
	}

	private IEnumerator Score(Vector3 nextServe)
	{
		Audio.HitGround();
		if (Time.timeScale != 0f)
		{
			Time.timeScale = 0;
			yield return new WaitForSecondsRealtime(Settings.s.WaitAfterScore);
			Time.timeScale = 1;
		}
		Ball.Serve(nextServe);
	}

	private IEnumerator win()
	{
		Audio.Win();
		StartCoroutine(Score(new Vector3(0,100)));
		yield return new WaitForSecondsRealtime(Settings.s.WaitAfterWin);
		Skins.SwitchSkin();
		ResetGame();
	}

	
}
