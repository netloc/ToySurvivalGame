using UnityEngine;
using System.Collections;
using System;

public enum BuffNames
{
    Shield,
    Speed,
    Damage
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
                default:
                    // Do nothing the buff is not implemented
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
		