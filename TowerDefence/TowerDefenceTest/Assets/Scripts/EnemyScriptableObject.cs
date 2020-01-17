using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 52)]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField]
    private int health;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int minGold;
    [SerializeField]
    private int maxGold;


    public int Health { get => health; set => health = value; }
    public float Speed { get => speed; set => speed = value; }
    public int Damage { get => damage; set => damage = value; }
    public int MinGold { get => minGold; set => minGold = value; }
    public int MaxGold { get => maxGold; set => maxGold = value; }
}