using UnityEngine;

public class AudioManager : MonoBehaviour
{

	[Header("Source")]
	[SerializeField] private AudioSource Audio;

	[Header("Clips")] 
	[SerializeField] private AudioClip[] hitSounds;
	[SerializeField] private AudioClip hitGround;
	[SerializeField] private AudioClip hitWall;
	[SerializeField] private AudioClip applause;

	private int hit;
	
	public void Hit()
	{
		hit = hit % hitSounds.Length;
		Audio.PlayOneShot(hitSounds[hit++]);
	}

	public void HitGround()
	{
		Audio.PlayOneShot(hitGround);
	}

	public void HitWall()
	{
		Audio.PlayOneShot(hitWall);
	}

	public void Win()
	{
		Audio.PlayOneShot(applause);
	}
}
