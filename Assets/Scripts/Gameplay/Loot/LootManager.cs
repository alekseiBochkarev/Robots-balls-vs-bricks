using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    public static LootManager Instance;
    private List<LootSO> lootOnField;

    private void Awake()
    {
        lootOnField = new List<LootSO>();
    }

    public void AddLootToList(LootSO lootItem)
    {
        lootOnField.Add(lootItem);
    }

    public void GetLoot()
    {
        foreach (LootSO loot in lootOnField)
        {
            if (loot.GetType() == typeof(CoinLootSO))
                Coins.Instance.AddCoin(loot.dropLootQuantity);
            if (loot.GetType() == typeof(HealLootSO))
                Hero.Instance.HealUp(loot.dropLootQuantity);

            // Removes loot from lootOnField
            
                lootOnField.Remove(loot);
        }
    }
}
