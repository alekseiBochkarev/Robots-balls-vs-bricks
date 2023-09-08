using UnityEngine;

public class BlackHoleCloneBall : MonoBehaviour, IBall
{
    public GameObject hero;
    public int attackPower;
    public int attackPowerMultiplier = 5;
    private int damageTextFontSize;
    private Color damageTextColor;
    private float destroyTimer = 0.2f;

    void Start ()
    {
        hero = GameObject.Find("Hero");
        attackPower = hero.GetComponent<Hero>().AttackSkill * attackPowerMultiplier;
        damageTextColor = TextController.COLOR_BLACK;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }

    void Update ()
    {
        checkAndDestroy();
    }

    public int GetAttackPower
    {
        get
        {
            return attackPower;
        }
    }

    public int GetDamageTextFontSize
    {
        get
        {
            return damageTextFontSize;
        }
    }

    public Color GetDamageTextColor
    {
        get
        {
            return damageTextColor;
        }
    }
   
    public void checkAndDestroy()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void DestroyBall () {
        Destroy(this.gameObject);
    }
}
