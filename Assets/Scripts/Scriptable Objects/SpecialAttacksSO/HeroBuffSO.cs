using Assets.Scripts.Gameplay.HeroBuffs;
using UnityEngine;

[CreateAssetMenu(fileName = "New Special Attack", menuName = "Scriptable Objects/Special Attacks/HeroBuffSO")]
public class HeroBuffSO : SpecialAttackSO
{
    public HeroBuffsEnum heroBuffType;
    public int heroBuffValue;

    public HeroBuffSO()
    {
        attackTypeEnum = AttackTypeEnum.HeroBuff;
        maxUseAmount = 1;
    }
}
