using Assets.Scripts.Gameplay.Combo;

public class LaserHorizontalComboBallController : ComboBallController
{
    private void OnEnable()
    {
        Init();
        ComboLauncher.Instance.AddComboAmountOnScene();
        comboAttackBehaviour = gameObject.AddComponent<LaserHorizontalComboAttack>();
        //   afterCollisionBehaviour = new NoDestroy();
        DamageTextColor = TextController.COLOR_RED;
        DamageTextFontSize = TextController.FONT_SIZE_MAX;
    }
}