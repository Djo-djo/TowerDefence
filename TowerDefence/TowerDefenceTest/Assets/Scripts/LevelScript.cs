using TMPro;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    [SerializeField]
    private LevelScriptableObject levelData;
    private int gold;
    private int health;
    private int wave;
    private bool gameOver = false;

    private void Start()
    {
        Gold = levelData.Gold;
        Health = levelData.Health;
        Wave = 1;
    }

    public int Gold
    {
        get => gold;
        set
        {
            gold = value;
            GameObject.Find("Gold").GetComponent<TextMeshProUGUI>().text = $"Gold: {gold}";
        }
    }
    public int Health
    {
        get => health;
        set
        {
            health = value < 0 ? 0 : value;

            GameObject.Find("Health").GetComponent<TextMeshProUGUI>().text = $"Health: {health}";

            GameOver = health == 0;
        }
    }

    public int Wave
    {
        get => wave;
        set
        {
            wave = value;
            int wavesCount = GameObject.Find("Road").GetComponent<EnemySpawnPointScript>().waves.Length;
            if (wave <= wavesCount)
            {
                GameObject.Find("Wave").GetComponent<TextMeshProUGUI>().text = $"Wave: {wave}/{wavesCount}";
            }
        }
    }

    public bool GameOver
    {
        get => gameOver;
        set
        {
            gameOver = value;
            if (gameOver)
            {
                var gameOverPrefab = Instantiate(levelData.GameOverPrefab, Vector3.zero, Quaternion.identity);
                gameOverPrefab.GetComponent<TextMeshPro>().text = health > 0 ? "You win" : "Game Over";
            }
        }
    }
}