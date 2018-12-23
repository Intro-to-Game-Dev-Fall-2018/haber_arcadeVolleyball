using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

	[Header("Buttons")]
	[SerializeField] private Button _startButton;

	private void Awake()
	{
		_startButton.onClick.AddListener(LoadGameN);
	}

	private void LoadGameN()
	{
		SceneManager.LoadScene("Volleyball");
	}
}
