using Gameplay.StatsPanel;

namespace Gameplay.Health
{
    public class HealthPrefab : AbstractStatPrefab
    {
        private const string PathToSprites = "HealthPrefabSprites";

        private void Awake()
        {
            InitImageComponent();
            LoadSprites(PathToSprites);
        }
    }
}