using UnityEngine;

public class Ball : AbstractBall
{
    public Ball()
    {
        attackBehaviour = new NoAttack();
        afterCollisionBehaviour = new NoDestroy();
        damageTextColor = TextController.COLOR_YELLOW;
        damageTextFontSize = TextController.FONT_SIZE_STANDARD;
    }
}