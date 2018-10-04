using UnityEngine;

[CreateAssetMenu(menuName = "Game Skin")]
public class GameSkin : ScriptableObject
{
	[Header("General")]
	public string Name;

	[Header("Player")] 
	public SpriteSet PlayerSprite;
	public Color P1A = Color.white;
	public Color P1B = Color.white;
	public Color P2A = Color.white;
	public Color P2B = Color.white;
	
	[Header("Background")]
	public Sprite BackgroundSprite;
	public Color BackgroundColor = Color.black;

	[Header("Ball")] 
	public Sprite BallSprite;
	public Color BallColor = Color.white;

	[Header("GUI")] 
	public Color TitleColor = Color.blue;
	public Color ScoreColor = Color.white;

}
