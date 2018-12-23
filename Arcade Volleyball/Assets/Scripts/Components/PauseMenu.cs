using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] private Button _mainMenu;
	
	[SerializeField] private Canvas _menu;
	
	private bool _paused;
	
	private void Start () {
		_menu.gameObject.SetActive(false);
		_mainMenu.onClick.AddListener(LoadMenu);
	}
	
	public void Toggle()
	{
		if (!_paused)
		{
			Time.timeScale = 0;
			_menu.gameObject.SetActive(true);
			_paused = true;	
		}
		else
		{
			Time.timeScale = 1;
			_menu.gameObject.SetActive(false);
			_paused = false;	
			EventSystem.current.SetSelectedGameObject(null);
		}
	}
	
	private void Update ()
	{
		if (Input.GetButtonDown("Menu")) Toggle();
	}

	private void LoadMenu()
	{
		Toggle();
		SceneManager.LoadScene("Menu");
	}
}
