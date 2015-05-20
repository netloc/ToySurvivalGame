using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public enum BuffNames
{
	Shield,
	Speed,
	Damage,
    Bomb
}

public class BuffHandler : MonoBehaviour
{
	GameObject player;
	PlayerBuffs playerBuffs;

	public BuffNames Buff;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerBuffs = player.GetComponent<PlayerBuffs>();
	}

	// Update is called once per frame
	void Update()
	{
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
		{
			switch (Buff)
			{
				case BuffNames.Shield:
					playerBuffs.AddShieldBonus();
					break;
				case BuffNames.Speed:
					playerBuffs.AddSpeedBonus();
					break;
				case BuffNames.Damage:
					playerBuffs.AddDamageBonus();
					break;
                case BuffNames.Bomb:
                    GameObject.FindGameObjectsWithTag("Enemy").ToList().ForEach(x => Destroy(x));
                    break;
				default:
					// Do nothing the buff is not implemented
					break;
			}

			Destroy(this.gameObject);
		}
	}
}
		