public class InstaKillComboBallController : ComboBallController
{
    public string instaKillMessageText = "INSTAKILL COMBO";

    private void OnEnable() {
        Init();
        comboAttackBehaviour = gameObject.AddComponent<InstaKillComboAttack>();
        gameObject.GetComponent<InstaKillComboAttack>().instaKillMessageText = instaKillMessageText;
        
        DamageTextColor = TextController.COLOR_BLACK;
        DamageTextFontSize = TextController.FONT_SIZE_MAX;
    }
}
