using UnityEngine;

public class BlackHoleComboAttack : MonoBehaviour, ComboAttackBehaviour
{
    GameObject ballPrefab;

    public void ComboAttack(Vector3 position, GameObject brick)
    {
       ballPrefab = Resources.Load<GameObject>("BlackHoleCloneBall");
       GameObject bombCloneBall = Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
