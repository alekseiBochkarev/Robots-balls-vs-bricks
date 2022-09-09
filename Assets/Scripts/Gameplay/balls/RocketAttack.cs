using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAttack : MonoBehaviour, AttackBehaviour
{
    
    GameObject ballPrefab;

    public void SpecialAttack(Vector3 position, GameObject brick)
    {
       ballPrefab = Resources.Load<GameObject>("RocketClone");
       GameObject rocket = Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
