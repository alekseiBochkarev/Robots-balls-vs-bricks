using UnityEngine;

namespace Scriptable_Objects.LootInChest
{
    [CreateAssetMenu(fileName = "New Loot in chest", menuName = "Scriptable Objects/Loot in chest/LootBallSO")]
    public class LootBallSO : LootInChestSO
    {
        
        public LootBallSO()
        {
            lootInChestTypeEnum = LootInChestTypeEnum.LootBall;
        }
    }
}