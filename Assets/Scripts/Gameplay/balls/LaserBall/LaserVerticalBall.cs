public class LaserVerticalBall : AbstractBall
{
    public LaserVerticalBall()
    {
        attackBehaviour = new LaserVerticalAttack();
        afterCollisionBehaviour = new NoDestroy();
        damageTextColor = TextController.COLOR_RED;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }
}
