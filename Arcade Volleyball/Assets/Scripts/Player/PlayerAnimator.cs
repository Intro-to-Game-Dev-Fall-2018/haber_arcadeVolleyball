using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

	public SpriteSet Sprites;
	[SerializeField] private SpriteRenderer Renderer;
	
	private PlayerMotor _motor;
	
	private int _lastSpriteChange;
	private bool _activeSprite;

	private void Start ()
	{
		_motor = GetComponentInParent<PlayerMotor>();
	}
	
	public void SetColor(Color color)
	{
		Renderer.color = color;
	}
	
	private void Update()
	{
		if (_motor.Walking() && Time.frameCount > _lastSpriteChange + Sprites.FramesPerSprite)
		{
			_lastSpriteChange = Time.frameCount;
			_activeSprite = !_activeSprite;
		}

		if (!_motor.Grounded()) Renderer.sprite = Sprites.JumpSprite;
		else Renderer.sprite = _activeSprite ? Sprites.GroundSprite1 : Sprites.GroundSprite2;
	}
}
