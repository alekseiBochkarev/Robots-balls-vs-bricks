using Scriptable_Objects.LootInChest;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UI.LootInChestSelection
{
    public class LootInChestDisplay : MonoBehaviour
    {
        [Header("UI Stats")]
        [SerializeField] private TextMeshProUGUI lootInChestName;
        [SerializeField] private Image lootInChestImage;
       // [SerializeField] private TextMeshProUGUI specialAttackDescription;
      private LootInChestSO lootInChestSO;

       private void OnEnable()
       {
           
        }

        public void DisplayLootInChest(LootInChestSO _lootInChest)
        {
            lootInChestSO = _lootInChest;
            // Display Choosen Special Attack
            lootInChestName.text = Translator.Translate(_lootInChest.lootInChestName);
            lootInChestImage.sprite = _lootInChest.Image;
        }

        public void AddLootOnClick()
        {
            //Add specAttack
            if (lootInChestSO.GetType() == typeof(LootBallSO))
                //Balls.Instance.HeroStats.UpgradeStats(lootInChestSO.heroStats, 1);
                HeroStats.UpgradeStats(lootInChestSO.heroStats, 1);

            //Clear Loot in UI
            Destroy(this.gameObject);

            //Hide the panel
        }
    }
}