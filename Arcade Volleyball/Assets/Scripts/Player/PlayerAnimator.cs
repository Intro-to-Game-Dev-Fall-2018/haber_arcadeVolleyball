using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

	public int FramesPerSprite = 12;
	public Sprite GroundSprite2;
	public Sprite GroundSprite1;
	public Sprite JumpSprite;
	
	private PlayerMotor _motor;
	private SpriteRenderer _renderer;
	private int _lastSpriteChange;
	private bool _activeSprite;
	
	private void Start ()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_motor = GetComponentInParent<PlayerMotor>();
	}
	
	private void Update()
	{
		if (_motor.Walking() && Time.frameCount > _lastSpriteChange + FramesPerSprite)
		{
			_lastSpriteChange = Time.frameCount;
			_activeSprite = !_activeSprite;
		}

		if (!_motor.Grounded()) _renderer.sprite = JumpSprite;
		else _renderer.sprite = _activeSprite ? GroundSprite1 : GroundSprite2;
	}
}
