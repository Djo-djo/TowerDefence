using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private int maxHealth;
    [SerializeField]
    private GameObject currentHealthPrefab;
    private int currentHealth;
    private float originalScale;

    public int CurrentHealth
    {
        get => currentHealth; set
        {
            currentHealth = value;
            Vector3 tmpScale = currentHealthPrefab.transform.localScale;
            tmpScale.x = (float)currentHealth / (float)maxHealth * originalScale;
            currentHealthPrefab.transform.localScale = tmpScale;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth = transform.parent.gameObject.GetComponent<EnemyScript>().EnemyData.Health;
        originalScale = currentHealthPrefab.transform.localScale.x;
    }
}