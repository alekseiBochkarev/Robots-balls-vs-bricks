using UnityEngine;

namespace Scriptable_Objects.LootInChest
{
    [CreateAssetMenu(fileName = "New Loot in chest", menuName = "Scriptable Objects/Loot in chest")]
    public class LootInChestSO: ScriptableObject
    {
        public string lootInChestName;
        public Sprite Image;
        public LootInChestTypeEnum lootInChestTypeEnum;
        public int dropChance;
        public int dropLootQuantity;
        public HeroStats.HeroStatsEnum heroStats;
    }
    public enum LootInChestTypeEnum { LootBall, Coin }
}