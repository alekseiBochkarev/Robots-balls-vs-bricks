using UnityEngine;

public class LaserCrossAttack : MonoBehaviour, AttackBehaviour
{
    GameObject ballPrefab;

    public void SpecialAttack(Vector3 position)
    {
       ballPrefab = Resources.Load<GameObject>("LaserCrossCloneBall");
       GameObject laserBall = Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
