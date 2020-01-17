using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data", order = 54)]
public class LevelScriptableObject : ScriptableObject
{
    [SerializeField]
    private int gold;
    [SerializeField]
    private int health;
    [SerializeField]
    private GameObject gameOverPrefab;

    public int Gold => gold;

    public int Health => health;

    public GameObject GameOverPrefab => gameOverPrefab;
}