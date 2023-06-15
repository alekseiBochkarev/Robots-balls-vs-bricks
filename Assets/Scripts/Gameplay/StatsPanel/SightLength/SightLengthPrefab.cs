using Gameplay.StatsPanel;

public class SightLengthPrefab : AbstractStatPrefab
{
    private const string PathToSprites = "SightLengthPrefabSprites";

    private void Awake()
    {
        InitImageComponent();
        LoadSprites(PathToSprites);
    }
}
