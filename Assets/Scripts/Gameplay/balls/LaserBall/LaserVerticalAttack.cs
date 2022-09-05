using UnityEngine;

public class LaserVerticalAttack : MonoBehaviour, AttackBehaviour
{
    GameObject ballPrefab;

    public void SpecialAttack(Vector3 position)
    {
       ballPrefab = Resources.Load<GameObject>("LaserVerticalCloneBall");
       GameObject laserBall = Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
