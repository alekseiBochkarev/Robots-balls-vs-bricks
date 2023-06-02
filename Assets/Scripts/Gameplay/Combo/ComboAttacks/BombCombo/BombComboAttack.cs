using UnityEngine;

public class BombComboAttack : MonoBehaviour, ComboAttackBehaviour
{
    GameObject ballPrefab;

    public void ComboAttack(Vector3 position, GameObject brick)
    {
       ballPrefab = Resources.Load<GameObject>("BombCloneBall");
       GameObject bombCloneBall = Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
