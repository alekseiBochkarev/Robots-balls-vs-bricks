using System.Collections.Generic;
using Assets.Scripts.Data_Managing;
using UnityEngine;

namespace Gameplay.Loot
{
    public class LootBag : MonoBehaviour
    {
        public GameObject droppedItemPrefab;
        public List<LootSO> lootList;

        private readonly int _sortingOrderThirty = 30;

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
            var parentPosition = this.transform.position;

            if (droppedItems != null)
            {
                foreach (LootSO singleItem in droppedItems)
                {
                    // Спавним Родитель лута
                    GameObject lootItem = Instantiate(droppedItemPrefab, parentPosition, Quaternion.identity);

                    // Проставляем lootSO
                    var lootItemComponent = lootItem.GetComponent<LootItem>();
                    lootItemComponent.lootSo = singleItem;

                    // Спавним лут и назначем его чайлдом Родителя лута (LootItem) и выставляем sortingOrder
                    var lootPrefab = Instantiate(lootItemComponent.lootSo.lootObject, parentPosition,
                        Quaternion.identity);
                    lootPrefab.transform.SetParent(lootItem.transform);

                    lootPrefab.GetComponent<SpriteRenderer>().sortingOrder = _sortingOrderThirty;
                }
            }
        }
    }
}