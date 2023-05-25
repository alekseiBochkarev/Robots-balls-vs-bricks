public class BombBall : AbstractBall
{
    private void Awake() {
        Init();
       attackBehaviour = gameObject.AddComponent<BombAttack>();
     //   afterCollisionBehaviour = new NoDestroy();
        damageTextColor = TextController.COLOR_RED;
        damageTextFontSize = TextController.FONT_SIZE_MAX; 
    }
}
