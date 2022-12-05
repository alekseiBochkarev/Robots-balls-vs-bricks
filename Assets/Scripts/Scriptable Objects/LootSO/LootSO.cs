using UnityEngine;

[CreateAssetMenu(fileName = "New Loot", menuName = "Loot/Simple Loot")]
public class LootSO : ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;
    public int dropLootQuantity;
}
