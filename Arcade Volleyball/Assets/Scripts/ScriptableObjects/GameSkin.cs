using UnityEngine;

[CreateAssetMenu(menuName = "Game Skin")]
public class GameSkin : ScriptableObject
{
	[Header("General")]
	public string Name;

	[Header("Player")] 
	public SpriteSet PlayerSprite;
	public Color P1A;
	public Color P1B;
	public Color P2A;
	public Color P2B;
	
	[Header("Background")]
	public Sprite BackgroundSprite;
	public Color BackgroundColor;

	[Header("Ball")] 
	public Sprite BallSprite;
	public Color BallColor;

	[Header("GUI")] 
	public Color TitleColor;
	public Color ScoreColor;

}
