using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBall : AbstractBall
{
    public RocketBall()
    {
        attackBehaviour = new RocketAttack();
        afterCollisionBehaviour = new NoDestroy();
        damageTextColor = TextController.COLOR_BLACK;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }
        
}
