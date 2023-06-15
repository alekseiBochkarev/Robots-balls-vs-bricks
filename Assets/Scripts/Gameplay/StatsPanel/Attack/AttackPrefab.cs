namespace Gameplay.StatsPanel.Attack
{
    public class AttackPrefab : AbstractStatPrefab
    {
        private const string PathToSprites = "AttackPrefabSprites";

        private void Awake()
        {
            InitImageComponent();
            LoadSprites(PathToSprites);
        }
    }
}
