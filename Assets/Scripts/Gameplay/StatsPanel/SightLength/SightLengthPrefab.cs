using System.Collections;
using System.Collections.Generic;
using Gameplay.StatsPanel;
using UnityEngine;

public class SightLengthPrefab : AbstractStatPrefab
{
    private const string PathToSprites = "SightLengthPrefabSprites";

    private void Awake()
    {
        LoadSprites(PathToSprites);
    }
}
