namespace Gameplay.StatsPanel.StarterBalls
{
    public class StarterBallsPrefab : AbstractStatPrefab
    {
        private const string PathToSprites = "StarterBallsPrefabSprites";

        private void Awake()
        {
            LoadSprites(PathToSprites);
        }
    }
}