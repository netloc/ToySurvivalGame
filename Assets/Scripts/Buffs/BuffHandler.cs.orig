using UnityEngine;
using System.Collections;
using System;

public enum Buffs
{
    Shield,
    Speed
};

public class BuffHandler : MonoBehaviour 
{ 
	GameObject player;
	PlayerHealth playerHealth;
	PlayerBuffs playerBuffs;
	public Buffs Buff;

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
			case Buffs.Shield:
				playerBuffs.AddShieldBonus ();
				break;
            case Buffs.Speed:
                playerBuffs.AddSpeedBonus();
                Destroy(this.gameObject);
                break;
			default:
				// Do nothing the buff is not implemented
				break;
			}

			Destroy (this.gameObject);
		}
	}
}
