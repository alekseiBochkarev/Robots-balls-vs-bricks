public class LaserCrossComboBallController : ComboBallController
{
    private void OnEnable()
    {
        Init();
        comboAttackBehaviour = gameObject.AddComponent<LaserCrossComboAttack>();
        // afterCollisionBehaviour = new NoDestroy();
        DamageTextColor = TextController.COLOR_RED;
        DamageTextFontSize = TextController.FONT_SIZE_MAX;
    }
}