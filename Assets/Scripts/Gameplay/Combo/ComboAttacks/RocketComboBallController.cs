using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketComboBallController : ComboBallController
{
    private void Awake()
    {
        Init();
        comboAttackBehaviour = gameObject.AddComponent<RocketComboAttack>();
        gameObject.GetComponent<RocketComboAttack>().AttackPower = AttackPower;
        DamageTextColor = TextController.COLOR_BLACK;
        DamageTextFontSize = TextController.FONT_SIZE_MAX;
        gameObject.GetComponent<RocketComboAttack>().DamageTextColor = DamageTextColor;
        gameObject.GetComponent<RocketComboAttack>().DamageTextFontSize = DamageTextFontSize;
    }
}