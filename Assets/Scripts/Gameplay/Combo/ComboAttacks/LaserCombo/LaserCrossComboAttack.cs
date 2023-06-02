using UnityEngine;

public class LaserCrossComboAttack : MonoBehaviour, ComboAttackBehaviour
{
    GameObject horizontalBallPrefab;
    GameObject verticalBallPrefab;

    public void ComboAttack(Vector3 position, GameObject brick)
    {
       horizontalBallPrefab = Resources.Load<GameObject>("LaserHorizontalCloneBall");
       verticalBallPrefab = Resources.Load<GameObject>("LaserVerticalCloneBall");

       GameObject laserHorizontalBall = Instantiate(horizontalBallPrefab, position, Quaternion.identity);
       GameObject laserVerticalBall = Instantiate(verticalBallPrefab, position, Quaternion.identity);
    }
}
