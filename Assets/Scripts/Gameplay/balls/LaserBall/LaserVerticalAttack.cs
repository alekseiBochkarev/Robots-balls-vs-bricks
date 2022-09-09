using UnityEngine;

public class LaserVerticalAttack : MonoBehaviour, AttackBehaviour
{
    GameObject ballPrefab;

    public void SpecialAttack(Vector3 position, GameObject brick)
    {
       ballPrefab = Resources.Load<GameObject>("LaserVerticalCloneBall");
       GameObject laserBall = Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
