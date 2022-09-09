using UnityEngine;

public class LaserHorizontalAttack : MonoBehaviour, AttackBehaviour
{
    GameObject ballPrefab;

    public void SpecialAttack(Vector3 position, GameObject brick)
    {
       ballPrefab = Resources.Load<GameObject>("LaserHorizontalCloneBall");
       GameObject laserBall = Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
