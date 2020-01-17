using UnityEngine;

[CreateAssetMenu(fileName = "New TowerData", menuName = "Tower Data", order = 51)]
public class TowerScriptableObject : ScriptableObject
{
    [SerializeField]
    private int buildPrice;
    [SerializeField]
    private float range;
    [SerializeField]
    private float shootInterval;
    [SerializeField]
    private int damage;

    public int BuildPrice { get => buildPrice; set => buildPrice = value; }
    public float Range { get => range; set => range = value; }
    public float ShootInterval { get => shootInterval; set => shootInterval = value; }
    public int Damage { get => damage; set => damage = value; }
}