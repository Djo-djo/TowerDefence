using UnityEngine;

public class SellButtonScript : MonoBehaviour
{
    [HideInInspector]
    public GameObject tower;

    private void OnMouseUp()
    {
        GameObject.Find("LevelData").GetComponent<LevelScript>().Gold += tower.GetComponent<TowerScript>().TowerData.BuildPrice;
        Destroy(tower);
        Destroy(gameObject);
    }
}