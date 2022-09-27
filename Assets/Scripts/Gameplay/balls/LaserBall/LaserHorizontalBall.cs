public class LaserHorizontalBall : AbstractBall
{
    public LaserHorizontalBall()
    {
        attackBehaviour = new LaserHorizontalAttack();
     //   afterCollisionBehaviour = new NoDestroy();
        damageTextColor = TextController.COLOR_RED;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }
}
