using UnityEngine;

public class Ball : AbstractBall
{
    public Ball()
    {
        attackBehaviour = new NoAttack();
        afterCollisionBehaviour = new NoDestroy();
    }

}