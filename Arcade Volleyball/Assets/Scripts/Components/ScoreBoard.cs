using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI P1Scorecard;
	[SerializeField] private TextMeshProUGUI P2Scorecard;
	[SerializeField] private TextMeshProUGUI winText;
	
	private void Start ()
	{
		EventManager.i.onScore.AddListener(onScore);
	}

	private void onScore(GameState state)
	{
		P1Scorecard.text = state.P1score.ToString("D2");
		P2Scorecard.text = state.P2score.ToString("D2");

		if (state.P1score >= Settings.s.WinScore) winText.text = "Player 1 wins";
		else if (state.P2score >= Settings.s.WinScore) winText.text = "Player 2 wins";
		else winText.text = "";
	}
	
}
