using UnityEngine;
using System.Collections;

public class PlayerBuffs : MonoBehaviour {


	public int armor;
	
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {

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
}
