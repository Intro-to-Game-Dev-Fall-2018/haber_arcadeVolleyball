using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinManagerV2 : MonoBehaviour
{
	[Header("Objects")]
	[SerializeField] private PlayerAnimator P1A;
	[SerializeField] private PlayerAnimator P1B;
	[SerializeField] private PlayerAnimator P2A;
	[SerializeField] private PlayerAnimator P2B;
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
		P1A.Sprites = P1B.Sprites = P2A.Sprites = P2B.Sprites = skin.PlayerSprite;
		P1A.SetColor(skin.P1A);
		P1B.SetColor(skin.P1B);
		P2A.SetColor(skin.P2A);
		P2B.SetColor(skin.P2B);
		BG.sprite = skin.BackgroundSprite;
		Ball.sprite = skin.BallSprite;
		Ball.color = skin.BallColor;
		Title.color = skin.TitleColor;
		P1Score.color = P2Score.color = skin.ScoreColor;
		SceneCamera.backgroundColor = skin.BackgroundColor;
		text.text = skin.Name.ToUpper();
	}
}
