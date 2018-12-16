using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] private Canvas _menu;
	
	private bool _paused;
	
	private void Start () {
		_menu.gameObject.SetActive(false);
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
		}
	}
	
	private void Update ()
	{
		if (Input.GetButtonDown("Menu")) Toggle();
	}
}
