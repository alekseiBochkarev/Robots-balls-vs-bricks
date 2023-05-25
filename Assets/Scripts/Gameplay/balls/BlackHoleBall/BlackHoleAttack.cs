using UnityEngine;

public class BlackHoleAttack : MonoBehaviour, AttackBehaviour
{
    GameObject ballPrefab;

    public void SpecialAttack(Vector3 position, GameObject brick)
    {
       ballPrefab = Resources.Load<GameObject>("BlackHoleCloneBall");
       GameObject blackHoleCloneBall = Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
