using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Special Attack", menuName = "Scriptable Objects/Special Attacks/ComboAttackSO")]
public class ComboAttackSO : SpecialAttackSO
{
    public new ComboAttackEnum comboType;

    public ComboAttackSO()
    {
        attackTypeEnum = AttackTypeEnum.ComboAttack;
    }
}
