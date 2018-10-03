using System;
using System.Collections;
using System.Collections.Generic;
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
	
	private float _serveTimer;
	private Vector3 _nextServe;
	private bool _effect;
	
	private void Start ()
	{
		_ball = GameObject.Find("ball").GetComponent<BallController>();
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
		if ((_p1Score += 1) >= Settings.s.WinScore)
			win("Player 1 wins");
		else
			StartScoreEffect(_ball.P1.position);
	}
	
	public void P2Score()
	{
		if ((_p2Score += 1) >= Settings.s.WinScore)
			win("Player 2 wins");
		else
			StartScoreEffect(_ball.P2.position);
	}

	private void StartScoreEffect(Vector3 nextServe)
	{
		UpdateScore();
		_audio.HitGround();
		_nextServe = nextServe;
		_effect = true;
		Time.timeScale = 0;
		_serveTimer = Time.realtimeSinceStartup+1;
	}

	private void ScoreEffect()
	{	
		if (!(Time.realtimeSinceStartup > _serveTimer)) return;
		
		if (!_paused) Time.timeScale = 1;
		_effect = false;
		_ball.Serve(_nextServe);

	}

	private void win(string text)
	{
		_audio.Win();
		StartScoreEffect(new Vector3(0,100));
		winText.text = text;
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
		
		if (_effect) ScoreEffect();
		else if (!_paused) Time.timeScale = 1;
			
		if (Input.GetButtonDown("Menu")) PauseMenu();
	}

}
