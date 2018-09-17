using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

	public int FramesPerSprite = 12;
	public Sprite GroundSprite2;
	public Sprite GroundSprite1;
	public Sprite JumpSprite;
	
	private PlayerController _pc;
	private SpriteRenderer _renderer;
	private int _lastSpriteChange;
	private bool _activeSprite;
	
	void Start ()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_pc = GetComponent<PlayerController>();
	}
	
	private void Update()
	{
		if (_pc.Walking() && Time.frameCount > _lastSpriteChange + FramesPerSprite)
		{
			_lastSpriteChange = Time.frameCount;
			_activeSprite = !_activeSprite;
		}

		if (!_pc.Grounded()) _renderer.sprite = JumpSprite;
		else _renderer.sprite = _activeSprite ? GroundSprite1 : GroundSprite2;
	}
}
