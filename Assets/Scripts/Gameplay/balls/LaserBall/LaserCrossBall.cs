public class LaserCrossBall : AbstractBall
{
    /*public LaserCrossBall()
    {
        attackBehaviour = new LaserCrossAttack();
       // afterCollisionBehaviour = new NoDestroy();
        damageTextColor = TextController.COLOR_RED;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }*/

    private void Awake() {
        Init();
        attackBehaviour = gameObject.AddComponent<LaserCrossAttack>();
       // afterCollisionBehaviour = new NoDestroy();
        damageTextColor = TextController.COLOR_RED;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }
}
