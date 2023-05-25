using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour, AttackBehaviour
{
   public void SpecialAttack(Vector3 position, GameObject brick)
  {
    System.Random rn = new System.Random();
    int rnNum = rn.Next(1, 2);
   // Debug.Log("Random Num for InstaKill Ball is -> " + rnNum);
    if (rnNum == 1)
    {
      //  Debug.Log("Try Kill Brick with InstaKill Ball");
        brick.GetComponent<Brick>().SetState(brick.GetComponent<Brick>().fireStateBrick);
    }
  }
}