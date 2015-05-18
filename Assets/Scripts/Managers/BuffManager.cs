using UnityEngine;
using System.Collections;

public enum BuffNames
{
	Shield,
	Speed
}

public class BuffManager : MonoBehaviour 
{
	GameObject player;
	PlayerHealth playerHealth;
	PlayerBuffs playerBuffs;
	public BuffNames Buff;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		playerBuffs = player.GetComponent <PlayerBuffs> ();
	}
		
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player) {
			switch (Buff) {
			case BuffNames.Shield:
				playerBuffs.AddShieldBonus ();
				break;

			default:
				// Do nothing the buff is not implemented
				break;
			}

			Destroy (this.gameObject);
		}
	}
}
