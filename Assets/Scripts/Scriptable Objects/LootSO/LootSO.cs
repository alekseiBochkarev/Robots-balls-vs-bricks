using UnityEngine;

[CreateAssetMenu(fileName = "New Loot", menuName = "Loot/Simple Loot")]
public class LootSO : ScriptableObject
{
    public GameObject lootObject;
    public int dropChance;
    public int dropLootQuantity;
}
