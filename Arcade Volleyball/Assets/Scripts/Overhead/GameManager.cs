using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header("Menu Objects")]
	[SerializeField] private TextMeshProUGUI P1Scorecard;
	[SerializeField] private TextMeshProUGUI P2Scorecard;
	[SerializeField] private TextMeshProUGUI winText;
	[SerializeField] private Canvas Menu;
	[SerializeField] private Canvas instructions;
	[SerializeField] private AudioManager _audio;
	[SerializeField] private BallController _ball;
	
	private int _p1Score;
	private int _p2Score;
	private bool _paused;
	
	private void Start ()
	{
		Menu.gameObject.SetActive(false);
		Reset();
	}
	
	private void Reset()
	{
		instructions.gameObject.SetActive(true);
		winText.text = "";
		_p1Score = _p2Score = 00;
		UpdateScore();
	}

	public void unPause()
	{
		_paused = false;
	}
	
	public void ResetGame()
	{
		Reset();
		_ball.Reset();
	}

	public void P1Score()
	{
		StartCoroutine((_p1Score += 1) >= Settings.s.WinScore ?
			win("Player 1 wins") :
			ScoreEffect(_ball.P1.position));
	}
	
	public void P2Score()
	{
		StartCoroutine((_p2Score += 1) >= Settings.s.WinScore ? 
			win("Player 2 wins") : 
			ScoreEffect(_ball.P2.position));
	}

	private IEnumerator ScoreEffect(Vector3 nextServe)
	{
		UpdateScore();
		_audio.HitGround();
		Time.timeScale = 0;
		yield return new WaitForSecondsRealtime(1);
		if (!_paused) Time.timeScale = 1;
		_ball.Serve(nextServe);
	}

	private IEnumerator win(string text)
	{
		_audio.Win();
		StartCoroutine(ScoreEffect(new Vector3(0,100)));
		winText.text = text;
		yield return new WaitForSecondsRealtime(5);
		ResetGame();
	}

	private void UpdateScore()
	{
		P2Scorecard.text = _p2Score.ToString("D2");
		P1Scorecard.text = _p1Score.ToString("D2");
	}

	private void PauseMenu()
	{
		Time.timeScale = 0;
		Menu.gameObject.SetActive(true);
		_paused = true;
	}
	
	private void Update ()
	{
		if (!_ball.isStill()) instructions.gameObject.SetActive(false);
		
		else if (!_paused) Time.timeScale = 1;
			
		if (Input.GetButtonDown("Menu")) PauseMenu();
	}

}
