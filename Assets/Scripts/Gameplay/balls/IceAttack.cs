using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAttack : MonoBehaviour, AttackBehaviour
{
   public void SpecialAttack(Vector3 position, GameObject brick)
  {
    System.Random rn = new System.Random();
    int rnNum = rn.Next(1, 2);
    if (rnNum == 1)
    {
        if (brick.GetComponent<Brick>().getState() == brick.GetComponent<Brick>().idleStateBrick)
        {
            brick.GetComponent<Brick>().SetState(brick.GetComponent<Brick>().freezeStateBrick);
        }
    }
  }
}
