using System;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public static event Action onGameOver;
	public static event Action onScore;
	public static event Action<GameSkin> onSkinChanged = skin => { };

	public static void ChangeSkin(GameSkin skin)
	{
		onSkinChanged(skin);
	}

	public static void GameOver()
	{
		onGameOver();
	}

	public static void Score()
	{
		onScore();
	}

	public static void Reset()
	{
		
	}
	
}
