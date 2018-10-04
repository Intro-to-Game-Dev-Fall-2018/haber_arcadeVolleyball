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
	[SerializeField] private AudioManager Audio;
	[SerializeField] private BallController Ball;
	[SerializeField] private SkinManagerV2 Skins;
	
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
	
	public void ResetGame()
	{
		Reset();
		Ball.Reset();
	}

	public void P1Score()
	{
		StartCoroutine((_p1Score += 1) >= Settings.s.WinScore ?
			win("Player 1 wins") :
			Score(Ball.P1.position));
	}
	
	public void P2Score()
	{
		StartCoroutine((_p2Score += 1) >= Settings.s.WinScore ? 
			win("Player 2 wins") : 
			Score(Ball.P2.position));
	}

	private IEnumerator Score(Vector3 nextServe)
	{
		UpdateScore();
		Audio.HitGround();
		Time.timeScale = 0;
		yield return new WaitForSecondsRealtime(Settings.s.WaitAfterScore);
		if (!_paused) Time.timeScale = 1;
		Ball.Serve(nextServe);
	}

	private IEnumerator win(string text)
	{
		Audio.Win();
		StartCoroutine(Score(new Vector3(0,100)));
		winText.text = text;
		yield return new WaitForSecondsRealtime(Settings.s.WaitAfterWin);
		Skins.SwitchSkin();
		ResetGame();
	}

	private void UpdateScore()
	{
		P2Scorecard.text = _p2Score.ToString("D2");
		P1Scorecard.text = _p1Score.ToString("D2");
	}

	public void PauseMenu()
	{
		if (!_paused)
		{
			Time.timeScale = 0;
			Menu.gameObject.SetActive(true);
			_paused = true;	
		}
		else
		{
			Time.timeScale = 1;
			Menu.gameObject.SetActive(false);
			_paused = false;	
		}
	}
	
	private void Update ()
	{
		if (!Ball.isStill()) instructions.gameObject.SetActive(false);
		if (Input.GetButtonDown("Menu")) PauseMenu();
	}
}
