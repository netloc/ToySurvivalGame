using UnityEngine;
using System.Collections;

public class BuffSpawner : MonoBehaviour {

	public GameObject Shield;
		
	public GameObject MercuryFeet;

	public PlayerBuffs PlayerBuffs;

	public bool shieldOnMap = false;

	public bool MercuryFeetOnMap = false;

	void Awake() {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void PossiblySpawnBuff(Transform transform)
	{
		int value = Random.Range (0, 100);

		if (value >= 50) {
			if (PlayerBuffs.armor > 0 || shieldOnMap)
			{
				// Player already has buff
				shieldOnMap = false;
			}
			else
			{
				var testValue = transform.position;

				testValue.y = 2;

				Instantiate (Shield, testValue, new Quaternion (0f, 45f, 90f, 45f));

				shieldOnMap = true;
			}
		} 
		else 
		{
			if (PlayerBuffs.hasSpeedBuff || MercuryFeetOnMap)
			{
				// PLayer already has buff
				MercuryFeetOnMap = false;
			}
			else
			{
				var testValue = transform.position;
				
				testValue.y = 1;
				
				Instantiate (MercuryFeet, testValue, new Quaternion (0f, 45f, 90f, 45f));

				MercuryFeetOnMap = true;
			}
		}

	}
}
