using UnityEngine;
using System.Collections;

public class PlayerBuffs : MonoBehaviour
{

    public int armor;
    public float speed;
    public bool hasSpeedBuff = false;
    public float timeLeft = 10.0f;


    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(hasSpeedBuff && timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                //Debug.Log(new { message = "Hit" });
                speed = 0;
                hasSpeedBuff = false;
            }
        }
    }

    public void AddShieldBonus()
    {
        armor += 3;
    }

    public void RemoveShieldTick()
    {
        armor -= 1;
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
}
