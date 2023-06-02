using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketComboAttack : MonoBehaviour, ComboAttackBehaviour
{
    private int attackPower;
    private int damageTextFontSize;
    private Color damageTextColor;

    public int AttackPower
    {
        get => attackPower;
        set => attackPower = value;
    }

    public int DamageTextFontSize
    {
        get => damageTextFontSize;
        set => damageTextFontSize = value;
    }

    public Color DamageTextColor
    {
        get => damageTextColor;
        set => damageTextColor = value;
    }

    public void ComboAttack(Vector3 position, GameObject brick)
    {
        if (brick != null)
        {
            //  Debug.Log("RocketComboAttack attack power " + attackPower);
            brick.GetComponent<Brick>().TakeDamage(attackPower, damageTextColor, damageTextFontSize);
        }
    }
}