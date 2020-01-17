using UnityEngine;

public class TowerPlaceScript : MonoBehaviour
{
    private GameObject tower;
    [SerializeField]
    private GameObject towersList;
    [SerializeField]
    private GameObject sellButtonPrefab;
    private GameObject sellButton;
    private GameObject towerSelection;
    private LevelScript level;

    public GameObject Tower { get => tower; set => tower = value; }

    private void Start()
    {
        level = GameObject.Find("LevelData").GetComponent<LevelScript>();
    }

    private void OnMouseUp()
    {
        if (level.GameOver)
        {
            return;
        }

        if (IsPlaceAvailable())
        {
            if (towerSelection == null)
            {
                towerSelection = Instantiate(towersList, transform.position, Quaternion.identity, transform);
            }
            else
            {
                Destroy(towerSelection);
                towerSelection = null;
            }
            sellButton = null;
        }
        else
        {
            if (sellButton == null)
            {
                sellButton = Instantiate(sellButtonPrefab, transform.position - new Vector3(0, 0.5f, 0), Quaternion.identity, transform);
                sellButton.GetComponent<SellButtonScript>().tower = tower;
            }
            else
            {
                Destroy(sellButton);
                sellButton = null;
            }
        }
    }

    private bool IsPlaceAvailable() => tower == null;
}