using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExoManager : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private SpriteRenderer _spriteImage;
    public int CurrentHealthLevel { private set; get; }

    private UpgradeStats upgradeStats;

    private void Awake()
    {
        InitImageComponent();
        Init();
        EventManager.UpgradeStats += LoadHealthLevelAndShowSprite;
    }

    public void Init()
    {
        if (upgradeStats == null)
            upgradeStats = new UpgradeStats();

        LoadHealthLevel();
        ChangeSprite(CurrentHealthLevel);
    }

    private void LoadHealthLevel()
    {
        CurrentHealthLevel = (int)upgradeStats.LoadUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeHealthLevel);
    }

    public void LoadHealthLevelAndShowSprite()
    {
        LoadHealthLevel();
        ChangeSprite(CurrentHealthLevel);
    }


    public void InitImageComponent()
    {
        _spriteImage = transform.GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(int level)
    {
        if (_spriteImage != null) _spriteImage.sprite = sprites[level - 1];
    }

    private void OnDestroy()
    {
        EventManager.UpgradeStats -= LoadHealthLevelAndShowSprite;
    }
}
