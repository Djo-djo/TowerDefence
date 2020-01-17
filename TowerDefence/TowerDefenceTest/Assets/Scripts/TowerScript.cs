using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField]
    private TowerScriptableObject towerData;
    [HideInInspector]
    public List<GameObject> enemiesInRange;
    [SerializeField]
    private GameObject bullet;

    private float lastShotTime;

    public TowerScriptableObject TowerData => towerData;

    // Start is called before the first frame update
    void Start()
    {
        enemiesInRange = new List<GameObject>();
        GetComponent<CircleCollider2D>().radius = towerData.Range;
        lastShotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = null;

        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToGoal = enemy.GetComponent<EnemyScript>().DistanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }

        if (target != null)
        {
            if (Time.time - lastShotTime > towerData.ShootInterval)
            {
                Shoot(target.GetComponent<Collider2D>());
                lastShotTime = Time.time;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            EnemyScript del = other.gameObject.GetComponent<EnemyScript>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyScript del = other.gameObject.GetComponent<EnemyScript>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    void Shoot(Collider2D target)
    {
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = bullet.transform.position.z;
        targetPosition.z = bullet.transform.position.z;

        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = startPosition;
        BulletBehaviourScript bulletComp = newBullet.GetComponent<BulletBehaviourScript>();
        bulletComp.target = target.gameObject;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;
        bulletComp.damage = towerData.Damage;
    }
}