public class BombComboBallController : ComboBallController
{
    private void Awake()
    {
        Init();
        comboAttackBehaviour = gameObject.AddComponent<BombComboAttack>();
        DamageTextColor = TextController.COLOR_RED;
        DamageTextFontSize = TextController.FONT_SIZE_MAX;
    }
}