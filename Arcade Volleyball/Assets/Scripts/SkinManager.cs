using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
	[SerializeField]
	public SpriteRenderer P1A;
	public SpriteRenderer P1B;
	public SpriteRenderer P2A;
	public SpriteRenderer P2B;
	public SpriteRenderer BG;
	public SpriteRenderer Ball;
	public TextMeshProUGUI Title;
	public Camera SceneCamera;
	public Text text;

	public Sprite BG1; 		//retro
	public Sprite BG2;		//simple
	public Sprite Ball1;	//simple

	private int _current;
	private void Start()
	{
		_current = 0;
		SwitchSkin();
	}

	public void SwitchSkin()
	{
		_current = (_current+=1)%4;
		
		// ReSharper disable once SwitchStatementMissingSomeCases
		switch (_current)
		{
			case 0:  monotone();
				break;
			case 1: regular();
				break;
			case 2: purp();
				break;
			case 3: coldwar();
				break;
		}
	}

	private void regular()
	{
		BG.sprite = BG1;
		BG.color = Color.white;
		Ball.sprite = Ball1;
		Ball.color = Color.white;
		P1A.color = Color.green;
		P1B.color = Color.yellow;
		P2A.color = Color.magenta;
		P2B.color = Color.red;
		Title.color = Color.blue;
		SceneCamera.backgroundColor = Color.black;
		text.text = "DEFAULT";
	}

	private void monotone()
	{
		regular();
		BG.sprite = BG2;
		P1A.color = P1B.color = P2A.color = P2B.color = Color.white;
		Title.color = Color.white;
		text.text = "MONO";
	}

	private void purp()
	{
		regular();
		BG.sprite = BG2;
		BG.color = Color.black;
		Ball.color = Color.black;
		P1A.color = P1B.color = P2A.color = P2B.color = Color.black;
		Title.color = Color.black;
		SceneCamera.backgroundColor = new Color(.725f,.717f,066f);
		text.text = "PURP";
	}

	private void coldwar()
	{
		P1A.color = P1B.color = Color.white;
		P2A.color = P2B.color = Color.yellow;
		Ball.color = Color.blue;
		Title.color = Color.grey;
		SceneCamera.backgroundColor = Color.red;
		text.text = "COLD WAR";
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
