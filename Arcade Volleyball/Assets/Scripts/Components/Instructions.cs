using UnityEngine;

public class Instructions : MonoBehaviour
{

	[SerializeField] private BallController _ball;
	[SerializeField] private GameObject _p2Instructions;
	

	private void Start()
	{
		gameObject.SetActive(true);
		if (!PVPswitch.pvp) _p2Instructions.SetActive(false);
	}

	private void Update () {
//		if (!_ball.isStill()) gameObject.SetActive(false);
		if (!_ball.isStill()) Destroy(gameObject);

	}
}
