using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class OnScoreEvent : UnityEvent<GameState> {}

public class EventManager : MonoBehaviour
{
	public static EventManager i;
	
	public UnityEvent onGameOver;
	public OnScoreEvent onScore;
	
	private void Awake()
	{
		if (i == null) i = this;
		else Destroy(gameObject);
		
		onScore = new OnScoreEvent();
		onGameOver = new UnityEvent();
	}
}
