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
        GameObject goal = GameObject.FindWithTag("Brick");
        if (goal != null)
        {
            Debug.Log("youhooooooooo");
            rocket.GetComponent<AbstractBall>().GetReadyAndAddForce(goal.transform.position);
        }    
        else 
         rocket.GetComponent<AbstractBall>().Disable();
         Destroy(rocket);

    }
}
