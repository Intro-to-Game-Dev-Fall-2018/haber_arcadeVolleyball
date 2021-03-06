﻿using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
	
	[Header("Game Settings")]
	public int WinScore = 7;
	public int MaxTouches = 3;

	[Header("Ball Settings")] 
	public float BallSpeed = 8f;
	public float BallGravity = -.0001f;
	public float BallAcceleration = .001f;
	
	[Header("Player Settings")]
	public float PlayerSpeed = 8f;
	public float PlayerJumpSpeed = 20f;
	public float GroundLevel = -3f;

	[Header("Physics Settings")]
	public float CharacterSize = 1f;
	public bool Effects = true;
	
	[Header("Time Settings")] 
	public float WaitAfterScore = 1f;
	public float WaitAfterWin = 5f;

	[Header("NPC Settings")] 
	public float WaitBeforeServe = 1f;

}
