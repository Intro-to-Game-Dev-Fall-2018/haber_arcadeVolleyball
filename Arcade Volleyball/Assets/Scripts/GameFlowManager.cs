using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
	public TextMeshProUGUI P1Scorecard;
	public TextMeshProUGUI P2Scorecard;
	public Canvas Menu;
	public GameObject Game;

	private int _p1Score;
	private int _p2Score;
	private bool _gameStart;
	private BallController _ball;
	
	private void Start ()
	{
		_ball = GameObject.Find("ball").GetComponent<BallController>();
		Menu.gameObject.SetActive(false);
		Game.SetActive(false);
		_p1Score=_p2Score = 00;
		_gameStart = false;
		UpdateScore();
	}
	

	public void P1Score()
	{
		_p1Score += 1;
		UpdateScore();
		_ball.Serve(_ball.P1.position);
	}
	
	public void P2Score()
	{
		_p2Score += 1;
		UpdateScore();
		_ball.Serve(_ball.P2.position);
	}

	private void UpdateScore()
	{
		P2Scorecard.text = _p2Score.ToString("D2");
		P1Scorecard.text = _p1Score.ToString("D2");
	}
	
	private void Update ()
	{
		if (!_gameStart&&Input.anyKey)
		{
			_gameStart = true;
			GameObject.Find("instructions").SetActive(false);
			Game.SetActive(true);
		}

		if (!Input.GetButtonDown("Menu")) return;
		Time.timeScale = 0;
		Menu.gameObject.SetActive(true);
	}
}
