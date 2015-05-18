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

	public void RemoveShieldTick()
	{
		armor -= 1;
	}
}
