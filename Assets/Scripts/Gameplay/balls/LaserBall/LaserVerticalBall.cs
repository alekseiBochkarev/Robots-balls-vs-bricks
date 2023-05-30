public class LaserVerticalBall : AbstractBall
{
    /*public LaserVerticalBall()
    {
        attackBehaviour = new LightningAttack();
     //   afterCollisionBehaviour = new NoDestroy();
        damageTextColor = TextController.COLOR_RED;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }*/
    
    private void Awake() {
        Init();
       attackBehaviour = gameObject.AddComponent<LaserVerticalAttack>();
     //   afterCollisionBehaviour = new NoDestroy();
        damageTextColor = TextController.COLOR_RED;
        damageTextFontSize = TextController.FONT_SIZE_MAX; 
    }
}
