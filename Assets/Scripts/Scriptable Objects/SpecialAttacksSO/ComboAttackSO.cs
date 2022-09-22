using Assets.Scripts.Gameplay.Combo;
using UnityEngine;

[CreateAssetMenu(fileName = "New Special Attack", menuName = "Scriptable Objects/Special Attacks/ComboAttackSO")]
public class ComboAttackSO : SpecialAttackSO
{
    public ComboAttackEnum comboType;
    public int initComboOnValue;


    public ComboAttackSO()
    {
        attackTypeEnum = AttackTypeEnum.ComboAttack;
    }
}
