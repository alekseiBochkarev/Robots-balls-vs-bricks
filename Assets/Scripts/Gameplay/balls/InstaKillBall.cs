public class InstaKillBall : AbstractBall
{
    public string instaKillMessageText = "INSTAKILL";
    public InstaKillBall()
    {
        attackBehaviour = new InstaKillAttack(instaKillMessageText);
        afterCollisionBehaviour = new NoDestroy();
        damageTextColor = TextController.COLOR_BLACK;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }
}
