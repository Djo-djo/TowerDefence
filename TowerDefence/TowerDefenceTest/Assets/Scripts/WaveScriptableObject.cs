using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WaveData", menuName = "Wave Data", order = 53)]
public class WaveScriptableObject : ScriptableObject
{
    [SerializeField]
    private int enemiesCount;
    [SerializeField]
    private List<GameObject> enemiesArray;
    [SerializeField]
    private float spawnInterval;

    public int EnemiesCount { get => enemiesCount; set => enemiesCount = value; }

    public List<GameObject> EnemiesArray { get => enemiesArray; set => enemiesArray = value; }

    public float SpawnInterval { get => spawnInterval; set => spawnInterval = value; }
}