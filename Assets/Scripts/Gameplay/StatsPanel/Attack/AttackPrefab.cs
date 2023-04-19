using UnityEngine;

namespace Gameplay.StatsPanel.Attack
{
    public class AttackPrefab : AbstractStatPrefab
    {
        private const string PathToSprites = "AttackPrefabSprites";

        private void Awake()
        {
            LoadSprites(PathToSprites);
        }
    }
}
