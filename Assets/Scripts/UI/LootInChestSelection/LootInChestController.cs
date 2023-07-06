using System.Collections.Generic;
using Scriptable_Objects.LootInChest;
using UnityEngine;

namespace UI.LootInChestSelection
{
    public class LootInChestController : MonoBehaviour
    {
        [SerializeField] private GameObject button;
        [SerializeField] private List<LootInChestSO> lootInChest;

        private void OnEnable()
        {
            
            button.GetComponent<LootInChestDisplay>().DisplayLootInChest(lootInChest[Random.Range(0, lootInChest.Count)]);
        }
    }
}