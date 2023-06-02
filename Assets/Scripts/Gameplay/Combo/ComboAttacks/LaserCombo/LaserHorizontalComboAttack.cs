using UnityEngine;

public class LaserHorizontalComboAttack : MonoBehaviour, ComboAttackBehaviour
{
    GameObject ballPrefab;

    public void ComboAttack(Vector3 position, GameObject brick)
    {
       ballPrefab = Resources.Load<GameObject>("LaserHorizontalCloneBall");
       GameObject laserBall = Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
