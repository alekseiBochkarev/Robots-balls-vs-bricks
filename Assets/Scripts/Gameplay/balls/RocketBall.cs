using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBall : AbstractBall
{
    public RocketBall()
    {
        attackBehaviour = new RocketAttack();
        afterCollisionBehaviour = new NoDestroy();
    }
        
}
