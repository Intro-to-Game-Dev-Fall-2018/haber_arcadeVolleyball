using System;
using UnityEngine;
using UnityEngine.Events;

public class OnScoreEvent : UnityEvent<GameState> {}
public class OnSkinChangedEvent : UnityEvent<GameSkin> {}

public class EventManager : MonoBehaviour
{
	public static EventManager i;
	
	public event Action onGameOver;
	public OnScoreEvent onScore;
	public OnSkinChangedEvent onSkinChanged;

	
	private void Awake()
	{
		if (i == null) i = this;
		else Destroy(gameObject);
		
		onScore = new OnScoreEvent();
		onSkinChanged = new OnSkinChangedEvent();
	}
}
