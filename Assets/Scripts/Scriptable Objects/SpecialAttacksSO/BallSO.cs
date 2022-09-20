using UnityEngine;

[CreateAssetMenu(fileName = "New Special Attack", menuName = "Scriptable Objects/Special Attacks/BallSO")]
public class BallSO : SpecialAttackSO
{
    public new BallsTypeEnum ballsType;
   
    public BallSO()
    {
        attackTypeEnum = AttackTypeEnum.SpecialAttack;
    }
}
