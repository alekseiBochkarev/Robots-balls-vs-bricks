using Assets.Scripts.Gameplay.Combo;

public class LaserVerticalComboBallController : ComboBallController
{
    private void OnEnable()
    {
        Init();
        ComboLauncher.Instance.AddComboAmountOnScene();
        comboAttackBehaviour = gameObject.AddComponent<LaserVerticalComboAttack>();
        //   afterCollisionBehaviour = new NoDestroy();
        DamageTextColor = TextController.COLOR_RED;
        DamageTextFontSize = TextController.FONT_SIZE_MAX;
    }
}