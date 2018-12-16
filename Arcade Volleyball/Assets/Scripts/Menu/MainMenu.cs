using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

	[Header("Buttons")]
	[SerializeField] private Button _startButton;
	[SerializeField] private Button _pvpButton;

	private void Awake()
	{
		_startButton.onClick.AddListener(()=>StartCoroutine(LoadGame()));
	
	}

	private IEnumerator LoadGame()
	{
		yield return new WaitForSeconds(.1f);
		AsyncOperation op = SceneManager.LoadSceneAsync("Volleyball", LoadSceneMode.Additive);
		while (!op.isDone) yield return new WaitForEndOfFrame();
		SceneManager.UnloadSceneAsync("Menu");
	}
}
