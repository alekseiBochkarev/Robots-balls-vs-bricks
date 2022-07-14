using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAttack : MonoBehaviour, AttackBehaviour
{
    
    GameObject ballPrefab;

    public void SpecialAttack(Vector3 position)
    {
       ballPrefab = Resources.Load<GameObject>("RocketClone");
       GameObject rocket = Instantiate(ballPrefab, position, Quaternion.identity);
    //    GameObject goal = GameObject.Find("leftBorder");
    //   rocket.GetComponent<AbstractBall>().GetReadyAndAddForce(new Vector2 (goal.transform.position.x, 0));   

    }
}
