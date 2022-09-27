using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnAfterCollision : MonoBehaviour, AfterCollisionBehaviour
{
    public void BehaviourAfterCollision()
    {
       // Debug.Log("return");
        BallLauncher.Instance.ReturnBallToStartPosition(this.gameObject.GetComponent<AbstractBall>());
    }
}
