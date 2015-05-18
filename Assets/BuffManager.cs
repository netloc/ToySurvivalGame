using UnityEngine;
using System.Collections;

public class BuffManager : MonoBehaviour 
{
	GameObject player;
	PlayerHealth playerHealth;
	PlayerBuffs playerBuffs;

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
		if (other.gameObject == player) 
		{
			playerBuffs.AddShieldBonus();
		}
	}
}
