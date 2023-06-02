using Assets.Scripts.Gameplay.Combo;

public class LaserCrossComboBallController : ComboBallController
{
    private void OnEnable()
    {
        Init();
        ComboLauncher.Instance.AddComboAmountOnScene();
        comboAttackBehaviour = gameObject.AddComponent<LaserCrossComboAttack>();
        // afterCollisionBehaviour = new NoDestroy();
        DamageTextColor = TextController.COLOR_RED;
        DamageTextFontSize = TextController.FONT_SIZE_MAX;
    }
}