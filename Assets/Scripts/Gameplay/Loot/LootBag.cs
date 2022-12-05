using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Data_Managing;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<LootSO> lootList = new List<LootSO>();

    private static int sortingOrder = 30;

    private SpriteRenderer sprRenderer;

    List<LootSO> GetDroppedItems()
    {
        List<LootSO> possibleDrops = new List<LootSO>();
        foreach (LootSO item in lootList)
        {
            if (ProbalitiesController.Instance.CheckProbality(item.dropChance))
            {
                possibleDrops.Add(item);
            }
        }
        if (possibleDrops.Count > 0)
        {
            return possibleDrops; // returns list of loot
        }
        return null; // returns no loot, if CheckProbality is false
    }

    public void InstantiateLoot()
    {
        List<LootSO> droppedItems = GetDroppedItems();
        if (droppedItems != null)
        {
            foreach(LootSO singleItem in droppedItems)
            {
                GameObject lootItem = Instantiate(droppedItemPrefab, transform.position, Quaternion.identity);

                //Init Sprite and sortingOrder for correct displaying
                sprRenderer = lootItem.GetComponent<SpriteRenderer>();
                sprRenderer.sprite = singleItem.lootSprite;
                sprRenderer.sortingOrder = sortingOrder;

                lootItem.GetComponent<LootItem>().itemQuantity = singleItem.dropLootQuantity;

                lootItem.GetComponent<LootItem>().lootSO = singleItem;
            }
        }
    }
}
