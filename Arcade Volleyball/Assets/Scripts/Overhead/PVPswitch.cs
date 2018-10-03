using UnityEngine;
using UnityEngine.UI;

public class PVPswitch : MonoBehaviour
{

	[SerializeField] private GameObject Player2;
	[SerializeField] private Text text;

	private ComputerController computer;
	private PlayerController player;
	private bool pvp;
	
	private void Start ()
	{
		computer = Player2.GetComponent<ComputerController>();
		player = Player2.GetComponent<PlayerController>();

		pvp = true;
		PVPSwitch();
	}

	public void PVPSwitch()
	{
		if (pvp)
		{
			computer.enabled = false;
			player.enabled = true;
			text.text = "PVP";
		}
		else
		{
			computer.enabled = true;
			player.enabled = false;
			text.text = "NPC";
		}

		pvp = !pvp;
	}
}
