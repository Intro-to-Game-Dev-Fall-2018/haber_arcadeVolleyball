using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
	[Header("Objects")]
	public SpriteRenderer P1A;
	public SpriteRenderer P1B;
	public SpriteRenderer P2A;
	public SpriteRenderer P2B;
	public SpriteRenderer BG;
	public SpriteRenderer Ball;
	public TextMeshProUGUI Title;
	public Camera SceneCamera;
	public Text text;

	[Header("Skins")]
	[SerializeField] private Sprite BG1; 		//retro
	[SerializeField] private Sprite BG2;		//simple
	[SerializeField] private Sprite BG3;      	//beach
	[SerializeField] private Sprite Ball1;		//simple
	[SerializeField] private Sprite Ball2;		//real

	private int _current;
	
	private void Start()
	{
		_current = 0;
		SwitchSkin();
	}

	public void SwitchSkin()
	{
		_current = (_current+=1)%5;
		
		// ReSharper disable once SwitchStatementMissingSomeCases
		switch (_current)
		{
			case 0:  Monotone();
				break;
			case 1: Regular();
				break;
			case 2: Purple();
				break;
			case 3: ColdWar();
				break;
			case 4: Beach();
				break;
		}
	}

	private void Regular()
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

	private void Monotone()
	{
		Regular();
		BG.sprite = BG2;
		P1A.color = P1B.color = P2A.color = P2B.color = Color.white;
		Title.color = Color.white;
		text.text = "MONO";
	}

	private void Purple()
	{
		Regular();
		BG.sprite = BG2;
		BG.color = Color.black;
		Ball.color = Color.black;
		P1A.color = P1B.color = P2A.color = P2B.color = Color.black;
		Title.color = Color.black;
		SceneCamera.backgroundColor = new Color(.725f,.717f,066f);
		text.text = "PURP";
	}

	private void ColdWar()
	{
		Regular();
		P1A.color = P1B.color = Color.white;
		P2A.color = P2B.color = Color.yellow;
		Ball.color = Color.blue;
		Title.color = Color.grey;
		SceneCamera.backgroundColor = Color.red;
		text.text = "COLD WAR";
	}

	private void Beach()
	{
		Regular();
		BG.sprite = BG3;
		P1A.color = P1B.color = Color.blue;
		P2A.color = P2B.color = Color.red;
		Ball.sprite = Ball2;
		Title.color = Color.white;
		SceneCamera.backgroundColor = new Color(0.5803f,0.9019f,1);
		text.text = "BEACH";
	}
	
}
