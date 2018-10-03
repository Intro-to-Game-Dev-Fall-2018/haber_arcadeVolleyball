using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Sprite Set")]
public class SpriteSet : ScriptableObject
{
	public int FramesPerSprite = 12;
	public Sprite GroundSprite1;
	public Sprite GroundSprite2;
	public Sprite JumpSprite;
}
