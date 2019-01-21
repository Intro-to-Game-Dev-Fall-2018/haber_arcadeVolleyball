using UnityEngine;
using UnityEngine.UI;

public class PVPswitch : MonoBehaviour
{

	[SerializeField] private GameObject Player2;
	[SerializeField] private Text text;

	private ComputerController computer;
	private PlayerController player;
	public static bool pvp;
	
	private void Start ()
	{
		if (Player2 != null)
		{
			computer = Player2.GetComponent<ComputerController>();
			player = Player2.GetComponent<PlayerController>();
		}

		UpdateText();
	}

	public void SetPVP()
	{
		pvp = true;
		UpdateText();
	}
	
	public void SetPVE()
	{
		pvp = false;
		UpdateText();
	}

	public void Toggle()
	{
		pvp = !pvp;
		UpdateText();
	}

	private void UpdateText()
	{
		if (pvp)
		{
			if (text!=null) text.text = "PVP";
			if (Player2 == null) return;
			computer.activate();
			computer.enabled = false;
			player.enabled = true;
		}
		else
		{
			if (text!=null) text.text = "NPC";
			if (Player2 == null) return;

			computer.enabled = true;
			player.enabled = false;
			computer.activate();
		}
	}
}
