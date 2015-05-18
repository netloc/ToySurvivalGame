using UnityEngine;
using System.Collections;

public class PlayerBuffs : MonoBehaviour {

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

		if (armor > 0) {
			armor--;
		} else {
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
}
