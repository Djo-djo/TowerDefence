using UnityEngine;

public class EnemySpawnPointScript : MonoBehaviour
{
    public GameObject[] waypoints;

    public WaveScriptableObject[] waves;
    public int timeBetweenWaves = 5;

    private float lastSpawnTime;
    private LevelScript level;
    private int enemiesSpawned = 0;


    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
        level = GameObject.Find("LevelData").GetComponent<LevelScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (level.GameOver)
        {
            return;
        }

        int wave = level.Wave - 1;
        if (wave < waves.Length)
        {
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[wave].SpawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                timeInterval > spawnInterval) &&
                enemiesSpawned < waves[wave].EnemiesCount)
            {
                lastSpawnTime = Time.time;
                GameObject newEnemy = Instantiate(waves[wave].EnemiesArray[Random.Range(0, waves[wave].EnemiesArray.Count)]);
                newEnemy.GetComponent<EnemyScript>().waypoints = waypoints;
                enemiesSpawned++;
            }

            if (enemiesSpawned == waves[wave].EnemiesCount &&
                GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                level.Wave++;
                level.Gold += 20;
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
        }
        else
        {
            level.GameOver = true;
        }
    }
}