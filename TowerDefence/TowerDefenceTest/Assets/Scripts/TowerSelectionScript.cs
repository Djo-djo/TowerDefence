using TMPro;
using UnityEngine;

public class TowerSelectionScript : MonoBehaviour
{
    [SerializeField]
    private GameObject tower;
    private int towerPrice;
    private LevelScript level;

    private void Start()
    {
        towerPrice = tower.GetComponent<TowerScript>().TowerData.BuildPrice;
        GetComponentInChildren<TextMeshPro>().text = towerPrice.ToString();
        level = GameObject.Find("LevelData").GetComponent<LevelScript>();
    }

    private void OnMouseUp()
    {
        if (IsTowerAvailable())
        {
            Transform towerPlace = transform.parent.parent;
            towerPlace.gameObject.GetComponent<TowerPlaceScript>().Tower = Instantiate(tower, towerPlace.position + new Vector3(0, 1, 0), Quaternion.identity, towerPlace);
            Destroy(transform.parent.gameObject);
            level.Gold -= towerPrice;
        }
    }

    private bool IsTowerAvailable() => towerPrice <= level.Gold;
}