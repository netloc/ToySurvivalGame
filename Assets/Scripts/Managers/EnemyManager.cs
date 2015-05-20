using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //commit a thing test
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public static int EnemiesOnMap;


    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        if (EnemiesOnMap >= 50)
        {
            // Reached spawn limit
        }
        else
        {
            EnemiesOnMap += 1;

            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}
