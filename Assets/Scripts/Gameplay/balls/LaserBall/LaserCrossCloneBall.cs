using UnityEngine;

public class LaserCrossCloneBall : MonoBehaviour, IBall
{
    public GameObject hero;
    public int attackPower;
    private int damageTextFontSize;
    private Color damageTextColor;
    private float destroyTimer = 0.2f;

    void Start ()
    {
        hero = GameObject.Find("Hero");
        attackPower = hero.GetComponent<Hero>().attackSkill;
        damageTextColor = TextController.COLOR_RED;
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
}
