using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonComboAttack : MonoBehaviour, ComboAttackBehaviour
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
            brick.GetComponent<Brick>().TakeDamage(attackPower, damageTextColor, damageTextFontSize);
            System.Random rn = new System.Random();
            int rnNum = rn.Next(1, 2);
            if (rnNum == 1)
            {
                if (brick.GetComponent<Brick>().getState() == brick.GetComponent<Brick>().idleStateBrick)
                {
                    brick.GetComponent<Brick>().SetState(brick.GetComponent<Brick>().poisonStateBrick);
                }
            }
        }
    }
}