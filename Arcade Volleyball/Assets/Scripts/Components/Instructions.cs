using UnityEngine;

public class Instructions : MonoBehaviour
{

	[SerializeField] private BallController _ball;

	private void Start()
	{
		gameObject.SetActive(true);
	}

	private void Update () {
		if (!_ball.isStill()) gameObject.SetActive(false);
	}
}
