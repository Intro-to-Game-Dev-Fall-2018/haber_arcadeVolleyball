using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
	public TextMeshProUGUI P1Scorecard;
	public TextMeshProUGUI P2Scorecard;
	public Canvas Menu;

	private int _p1Score;
	private int _p2Score; 
	
	private void Start ()
	{
		Menu.gameObject.SetActive(false);
		_p1Score=_p2Score = 00;
		UpdateScore();
	}
	

	public void P1Score()
	{
		_p1Score += 1;
		UpdateScore();
	}
	
	public void P2Score()
	{
		_p2Score += 1;
		UpdateScore();
	}

	private void UpdateScore()
	{
		P2Scorecard.text = _p2Score.ToString("D2");
		P1Scorecard.text = _p1Score.ToString("D2");
	}
	
	void Update ()
	{
		if (Input.GetButtonDown("Menu"))
		{
			Time.timeScale = 0;
			Menu.gameObject.SetActive(true);
		}
	}
}
