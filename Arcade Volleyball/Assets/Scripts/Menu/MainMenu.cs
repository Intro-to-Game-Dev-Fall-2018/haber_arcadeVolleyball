using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void StartGame()
	{
		StartCoroutine(LoadGame());
	}
	
	private IEnumerator LoadGame()
	{
		yield return new WaitForSeconds(.1f);
		var op = SceneManager.LoadSceneAsync("Volleyball", LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync("Menu");
		yield return op;
	}
}
