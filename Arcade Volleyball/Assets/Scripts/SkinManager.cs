using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
	
	public SpriteRenderer P1A;
	public SpriteRenderer P1B;
	public SpriteRenderer P2A;
	public SpriteRenderer P2B;
	public SpriteRenderer BG;
	public SpriteRenderer Ball;
	public TextMeshProUGUI Title;
	public Camera SceneCamera;

	public Sprite BG1; 		//retro
	public Sprite BG2;		//simple
	public Sprite Ball1;	//simple

	private void Start()
	{
		regular();
	}

	private string regular()
	{
		BG.sprite = BG1;
		Ball.sprite = Ball1;
		P1A.color = Color.green;
		P1B.color = Color.yellow;
		P2A.color = Color.magenta;
		P2B.color = Color.red;
		Title.color = Color.blue;
		SceneCamera.backgroundColor = Color.black;
		return "default";
	}

	private string monotone()
	{
		regular();
		BG.sprite = BG2;
		P1A.color = P1B.color = P2A.color = P2B.color = Color.white;
		Title.color = Color.white;
		return "mono";
	}

	private string sepia()
	{
		regular();
		
		
		return "sepia";
	}
	
}

//public class Skin
//{
//	public string name;
//	public Color p1a, p1b, p2a, p2b, title, bgColor;
//	public Sprite players, background;
//
//	public Skin(string name, Color p1a,Color p1b, Color p2a, Color p2b,Color title, Color bgColor,
//		Sprite players,Sprite background)
//	{
//		this.name = name;
//		this.p1a = p1a;
//		this.p1b = p1b;
//		this.p2a = p2a;
//		this.p2b = p2b;
//		this.title = title;
//		this.bgColor = bgColor;
//		this.players = players;
//		this.background = background;
//	}
//}
