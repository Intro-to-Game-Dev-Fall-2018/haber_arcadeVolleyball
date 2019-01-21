using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

	[Header("Buttons")]
	[SerializeField] private Button _startButton;
	[SerializeField] private Button _startPVP;
	[SerializeField] private Button _startPVE;

	[SerializeField] private PVPswitch _pvpSwitch;

	private void Awake()
	{
		if (_startButton!= null) _startButton.onClick.AddListener(StartGame);
		if (_startPVP!=null) _startPVP.onClick.AddListener(StartPVP);
		if (_startPVE!=null) _startPVE.onClick.AddListener(StartPVE);
	}

	private void StartGame()
	{
		SceneManager.LoadScene("Volleyball");
	}

	private void StartPVP()
	{
		_pvpSwitch.SetPVP();
		StartGame();
	}
	
	private void StartPVE()
	{
		_pvpSwitch.SetPVE();
		StartGame();
	}
}
