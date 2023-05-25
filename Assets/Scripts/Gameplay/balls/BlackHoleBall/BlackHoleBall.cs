public class BlackHoleBall : AbstractBall
{
    private void Awake() {
        Init();
       attackBehaviour = gameObject.AddComponent<BlackHoleAttack>();
       damageTextColor = TextController.COLOR_BLACK;
        damageTextFontSize = TextController.FONT_SIZE_MAX; 
    }
}
