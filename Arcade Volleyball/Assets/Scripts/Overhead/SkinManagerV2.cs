using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinManagerV2 : MonoBehaviour
{
	[Header("Objects")]
	[SerializeField] private SpriteRenderer P1A;
	[SerializeField] private SpriteRenderer P1B;
	[SerializeField] private SpriteRenderer P2A;
	[SerializeField] private SpriteRenderer P2B;
	[SerializeField] private SpriteRenderer BG;
	[SerializeField] private SpriteRenderer Ball;
	[SerializeField] private TextMeshProUGUI Title;
	[SerializeField] private TextMeshProUGUI P1Score;
	[SerializeField] private TextMeshProUGUI P2Score;
	[SerializeField] private Camera SceneCamera;
	[SerializeField] private Text text;

	[Header("Skins")]
	[SerializeField] private GameSkin[] skins;

	private int _current;
	
	private void Start()
	{
		_current = 0;
		SwitchSkin();
	}

	public void SwitchSkin()
	{
		_current = _current % skins.Length;
		SwitchSkin(skins[_current++]);
	}
	
	private void SwitchSkin(GameSkin skin)
	{
		//P1A.sprite = P1B.sprite = P2A.sprite = P2B.sprite = skin.PlayerSprite;
		P1A.color = skin.P1A;
		P1B.color = skin.P1B;
		P2A.color = skin.P2A;
		P2B.color = skin.P2B;
		BG.sprite = skin.BackgroundSprite;
		Ball.sprite = skin.BallSprite;
		Ball.color = skin.BallColor;
		Title.color = skin.TitleColor;
		P1Score.color = P2Score.color = skin.ScoreColor;
		SceneCamera.backgroundColor = skin.BackgroundColor;
		text.text = skin.Name.ToUpper();
	}
//
//	private void Regular()
//	{
//		BG.sprite = BG1;
//		BG.color = Color.white;
//		Ball.sprite = Ball1;
//		Ball.color = Color.white;
//		P1A.color = Color.green;
//		P1B.color = Color.yellow;
//		P2A.color = Color.magenta;
//		P2B.color = Color.red;
//		Title.color = Color.blue;
//		SceneCamera.backgroundColor = Color.black;
//		text.text = "DEFAULT";
//	}

}
