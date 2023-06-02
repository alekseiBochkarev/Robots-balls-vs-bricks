using UnityEngine;

public class LaserVerticalComboAttack : MonoBehaviour, ComboAttackBehaviour
{
    GameObject ballPrefab;

    public void ComboAttack(Vector3 position, GameObject brick)
    {
       ballPrefab = Resources.Load<GameObject>("LaserVerticalCloneBall");
       GameObject laserBall = Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
