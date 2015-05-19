using UnityEngine;
using System.Collections;

public class PlayerBuffs : MonoBehaviour
{

    public int armor;
    public float speed;
    public int damage;
    public bool hasSpeedBuff = false;
    public bool hasDamageBuff = false;
    public float timeLeft = 10.0f;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((hasDamageBuff || hasSpeedBuff) && timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                //Debug.Log(new { message = "Hit" });
                RemoveSpeedBonus();
                RemoveDamageBonus();
                hasSpeedBuff = false;
                hasDamageBuff = false;

                timeLeft = 10f;
            }
        }

    }

    public void AddShieldBonus()
    {
        armor += 3;
    }

    // Returns true if a tick was removed
    public bool RemoveShieldTick()
    {
        bool HadShieldTick = true;

        if (armor > 0)
        {
            armor--;
        }
        else
        {
            HadShieldTick = false;
        }

        return HadShieldTick;
    }

    public void AddSpeedBonus()
    {
        speed += 12;
        hasSpeedBuff = true;
    }

    public void RemoveSpeedBonus()
    {
        if (hasSpeedBuff)
        {
            speed -= 12;
            hasSpeedBuff = false;
        }
    }

    public void AddDamageBonus()
    {
        damage += 10;
    }

    public void RemoveDamageBonus()
    {
        if (damage >= 10)
            damage -= 10;
    }
}
