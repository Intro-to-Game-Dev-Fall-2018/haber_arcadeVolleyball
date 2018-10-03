using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
	
	[Header("Game Settings")]
	public int WinScore;

	[Header("Ball Settings")] 
	public float BallSpeed = 8;
	public float BallGravity = -.0001f;
	public float BallAcceleration = .001f;
	
	[Header("PlayerSettings")]
	public float PlayerSpeed = 8;
	public float PlayerJumpSpeed = 20;
	public float GroundLevel = -3;

}
