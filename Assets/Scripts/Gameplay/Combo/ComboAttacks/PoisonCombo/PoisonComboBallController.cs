using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Gameplay.Combo;
using UnityEngine;

public class PoisonComboBallController : ComboBallController
{
    private void Awake()
    {
        Init();
        comboAttackBehaviour = gameObject.AddComponent<PoisonComboAttack>();
        gameObject.GetComponent<PoisonComboAttack>().AttackPower = AttackPower;
        DamageTextColor = TextController.COLOR_GREEN;
        DamageTextFontSize = TextController.FONT_SIZE_MAX;
        gameObject.GetComponent<PoisonComboAttack>().DamageTextColor = DamageTextColor;
        gameObject.GetComponent<PoisonComboAttack>().DamageTextFontSize = DamageTextFontSize;
    }
    
    private void OnEnable()
    {
        ComboLauncher.Instance.AddComboAmountOnScene();
    }
}