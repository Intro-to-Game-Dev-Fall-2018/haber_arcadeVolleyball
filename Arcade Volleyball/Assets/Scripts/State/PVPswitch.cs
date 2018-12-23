using UnityEngine;
using UnityEngine.UI;

public class PVPswitch : MonoBehaviour
{

	[SerializeField] private GameObject Player2;
	[SerializeField] private Text text;

	private ComputerController computer;
	private PlayerController player;
	private static bool pvp;
	
	private void Start ()
	{
		if (Player2 != null)
		{
			computer = Player2.GetComponent<ComputerController>();
			player = Player2.GetComponent<PlayerController>();
		}

		PVPSwitch();
	}

	public void Toggle()
	{
		pvp = !pvp;
		PVPSwitch();
	}

	public void PVPSwitch()
	{
		if (pvp)
		{
			text.text = "PVP";
			if (Player2 == null) return;
			computer.activate();
			computer.enabled = false;
			player.enabled = true;
		}
		else
		{
			text.text = "NPC";
			if (Player2 == null) return;

			computer.enabled = true;
			player.enabled = false;
			computer.activate();
		}
	}
}
