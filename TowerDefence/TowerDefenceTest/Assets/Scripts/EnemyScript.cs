using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private EnemyScriptableObject enemyData;
    [HideInInspector]
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    private LevelScript level;

    public delegate void EnemyDelegate(GameObject enemy);
    public EnemyDelegate enemyDelegate;

    public EnemyScriptableObject EnemyData => enemyData;

    // Start is called before the first frame update
    void Start()
    {
        lastWaypointSwitchTime = Time.time;
        level = GameObject.Find("LevelData").GetComponent<LevelScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;

        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / enemyData.Speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);

        if (gameObject.transform.position.x.Equals(endPosition.x) && gameObject.transform.position.y.Equals(endPosition.y))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;
            }
            else
            {
                Destroy(gameObject);

                level.Health -= enemyData.Damage;
            }
        }
    }

    public float DistanceToGoal()
    {
        float distance = 0;
        distance += Vector2.Distance(
            gameObject.transform.position,
            waypoints[currentWaypoint + 1].transform.position);
        for (int i = currentWaypoint + 1; i < waypoints.Length - 1; i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance += Vector2.Distance(startPosition, endPosition);
        }
        return distance;
    }

    private void OnDestroy()
    {
        if (enemyDelegate != null)
        {
            enemyDelegate(gameObject);
        }
    }
}