using UnityEngine;
using System.Collections;
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


