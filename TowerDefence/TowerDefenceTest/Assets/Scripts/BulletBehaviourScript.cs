using UnityEngine;

public class BulletBehaviourScript : MonoBehaviour
{
    public float speed = 5;
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public GameObject target;
    [HideInInspector]
    public Vector3 startPosition;
    [HideInInspector]
    public Vector3 targetPosition;
    private LevelScript level;

    private float distance;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
        level = GameObject.Find("LevelData").GetComponent<LevelScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                Transform healthBarTransform = target.transform.Find("EnemyHealth");
                HealthScript healthBar = healthBarTransform.gameObject.GetComponent<HealthScript>();
                healthBar.CurrentHealth -= damage;

                if (healthBar.CurrentHealth <= 0)
                {
                    EnemyScriptableObject enemyScriptableObject = target.GetComponent<EnemyScript>().EnemyData;
                    level.Gold += Random.Range(enemyScriptableObject.MinGold, enemyScriptableObject.MaxGold);

                    Destroy(target);
                }
            }
            Destroy(gameObject);
        }
    }
}