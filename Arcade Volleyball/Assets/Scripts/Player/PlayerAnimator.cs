using UnityEngine;


public class PlayerAnimator : MonoBehaviour
{

	public SpriteSet Sprites;
	
	private PlayerMotor _motor;
	private SpriteRenderer _renderer;
	private int _lastSpriteChange;
	private bool _activeSprite;

	private void Start ()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_motor = GetComponentInParent<PlayerMotor>();
	}
	
	public void SetColor(Color color)
	{
		_renderer.color = color;
	}
	
	private void Update()
	{
		if (_motor.Walking() && Time.frameCount > _lastSpriteChange + Sprites.FramesPerSprite)
		{
			_lastSpriteChange = Time.frameCount;
			_activeSprite = !_activeSprite;
		}

		if (!_motor.Grounded()) _renderer.sprite = Sprites.JumpSprite;
		else _renderer.sprite = _activeSprite ? Sprites.GroundSprite1 : Sprites.GroundSprite2;
	}
}
