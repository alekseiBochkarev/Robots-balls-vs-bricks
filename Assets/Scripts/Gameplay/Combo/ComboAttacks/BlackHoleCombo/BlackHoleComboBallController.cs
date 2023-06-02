using Assets.Scripts.Gameplay.Combo;

public class BlackHoleComboBallController : ComboBallController
{
    private void Awake()
    {
        Init();
        comboAttackBehaviour = gameObject.AddComponent<BlackHoleComboAttack>();
        DamageTextColor = TextController.COLOR_RED;
        DamageTextFontSize = TextController.FONT_SIZE_MAX;
    }
    
    private void OnEnable()
    {
        ComboLauncher.Instance.AddComboAmountOnScene();
    }
}