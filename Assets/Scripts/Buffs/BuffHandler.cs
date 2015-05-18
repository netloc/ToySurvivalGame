using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using System;

public enum Buffs
{
    Shield,
    Speed
};

public class BuffManager : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    PlayerBuffs playerBuffs;

    public Buffs buffNames;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerBuffs = player.GetComponent<PlayerBuffs>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        switch (buffNames)
        {
            case Buffs.Shield:
                playerBuffs.AddShieldBonus();
                break;
            case Buffs.Speed:
                playerBuffs.AddSpeedBonus();
                Destroy(this.gameObject);
                break;
        }
    }
}


=======

public enum BuffNames
{
	Shield,
	Speed
}

public class BuffHandler : MonoBehaviour 
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
>>>>>>> d460d14cf10ea9010bffc2fbbbefa5463b1c7362
