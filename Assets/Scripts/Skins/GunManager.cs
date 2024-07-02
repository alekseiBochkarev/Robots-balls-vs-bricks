using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private SpriteRenderer _spriteImage;
    public int CurrentAttackLevel { private set; get; }

    private UpgradeStats upgradeStats;

    private void Awake()
    {
        InitImageComponent();
        Init();
        EventManager.UpgradeStats += LoadAttackLevelAndShowSprite;
    }

    public void InitImageComponent()
    {
        _spriteImage = transform.GetComponent<SpriteRenderer>();
    }

    public void Init()
    {
        if (upgradeStats == null)
            upgradeStats = new UpgradeStats();

        LoadAttackLevel();
        ChangeSprite(CurrentAttackLevel);
    }

    private void LoadAttackLevel()
    {
        CurrentAttackLevel = (int)upgradeStats.LoadUpgradeLevel(UpgradeStats.UpgradeStatLevel.UpgradeAttackLevel);
    }

    public void ChangeSprite(int level)
    {
        if (_spriteImage != null) _spriteImage.sprite = sprites[level - 1];
    }

    public void LoadAttackLevelAndShowSprite()
    {
        LoadAttackLevel();
        ChangeSprite(CurrentAttackLevel);
    }

    private void OnDestroy()
    {
        EventManager.UpgradeStats -= LoadAttackLevelAndShowSprite;
    }
}
