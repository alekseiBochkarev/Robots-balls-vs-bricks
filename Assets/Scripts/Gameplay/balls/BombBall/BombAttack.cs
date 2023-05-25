using UnityEngine;

public class BombAttack : MonoBehaviour, AttackBehaviour
{
    GameObject ballPrefab;

    public void SpecialAttack(Vector3 position, GameObject brick)
    {
       ballPrefab = Resources.Load<GameObject>("BombCloneBall");
       GameObject bombCloneBall = Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
