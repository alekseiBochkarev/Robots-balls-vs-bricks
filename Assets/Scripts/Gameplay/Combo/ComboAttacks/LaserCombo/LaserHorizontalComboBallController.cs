public class LaserHorizontalComboBallController : ComboBallController
{
    private void OnEnable()
    {
        Init();
        comboAttackBehaviour = gameObject.AddComponent<LaserHorizontalComboAttack>();
        //   afterCollisionBehaviour = new NoDestroy();
        DamageTextColor = TextController.COLOR_RED;
        DamageTextFontSize = TextController.FONT_SIZE_MAX;
    }
}