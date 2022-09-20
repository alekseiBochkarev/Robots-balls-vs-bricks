using UnityEngine;

[CreateAssetMenu(fileName = "New Special Attack", menuName = "Scriptable Objects/Special Attacks")]
public class SpecialAttackSO : ScriptableObject
{
    public int specialAttackIndex;
    public string specialAttackName;
    public string specialAttackDescription;
    public Sprite specialAttackImage;
    public int maxUseAmount;
    public int currentUseAmount;
    public AttackTypeEnum attackTypeEnum;
}

public enum AttackTypeEnum { SpecialAttack, ComboAttack, HeroBuff }