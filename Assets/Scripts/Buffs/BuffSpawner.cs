using UnityEngine;
using System.Collections;

public class BuffSpawner : MonoBehaviour
{

    public GameObject Shield;

    public GameObject MercuryFeet;

    public GameObject Detonator;

    public GameObject DamageBoost;

    public PlayerBuffs PlayerBuffs;

    public static bool shieldOnMap = false;

    public static bool MercuryFeetOnMap = false;

    public static bool DamageBoostOnMap = false;

    public int enemiesNeededForMapClear = 25;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PossiblySpawnBuff(Transform transform)
    {
        int value = Random.Range(0, 100);

        if (value >= 25 && value <= 50)
        {
            if (PlayerBuffs.hasDamageBuff || DamageBoostOnMap)
            {
                DamageBoostOnMap = false;
            }
            else
            {
                var transformPosition = transform.position;

                transformPosition.y = 1;

                Instantiate(DamageBoost, transformPosition, new Quaternion(0f, 45f, 90f, 45f));

                DamageBoostOnMap = true;
            }
        }
        else if (value >= 0 && value <= 25)
        {
            if (PlayerBuffs.hasSpeedBuff || MercuryFeetOnMap)
            {
                // Player already has buff
                MercuryFeetOnMap = false;
            }
            else
            {
                var transformPosition = transform.position;

                transformPosition.y = 1;

                Instantiate(MercuryFeet, transformPosition, new Quaternion(0f, 45f, 90f, 45f));

                MercuryFeetOnMap = true;
            }
        }
        else if (value >= 50)
        {
            if (PlayerBuffs.armor > 0 || shieldOnMap)
            {
                // Player already has buff
                shieldOnMap = false;
            }
            else
            {
                var transformPosition = transform.position;

                transformPosition.y = 2;

                Instantiate(Shield, transformPosition, new Quaternion(0f, 45f, 90f, 45f));

                shieldOnMap = true;
            }
        }
        else if ((value >= 0 && value <= 10) && EnemyManager.EnemiesOnMap > enemiesNeededForMapClear)
        {
            var transformPosition = transform.position;

            transformPosition.y = 2;

            Instantiate(Detonator, transformPosition, new Quaternion(0f, 45f, 90f, 45f));
        }
        else
        {
            
        }

    }
}
