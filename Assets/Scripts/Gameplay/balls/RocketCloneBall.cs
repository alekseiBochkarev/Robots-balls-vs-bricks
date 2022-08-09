using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCloneBall : MonoBehaviour, IBall
{
    public GameObject hero;
    public int attackPower;
    private int damageTextFontSize;
    private Color damageTextColor;
    private float vision;
    Collider2D[] colliders;
    public int MoveSpeed = 7;
    Vector3 target;
    Vector3 diff;
    float rot_z;
    

    void Start ()
    {
        target = FindGoalToMove();
        hero = GameObject.Find("Hero");
        attackPower = hero.GetComponent<Hero>().attackSkill;
        damageTextColor = TextController.COLOR_BLACK;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }

    public Vector3 FindGoalToMove()
    {
        vision = 10f;
        Vector3 vector3 = new Vector3(0, 0, 0);
        colliders = Physics2D.OverlapCircleAll(transform.position, vision);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject == gameObject) continue;
            if (colliders[i].gameObject.GetComponent<Brick>() != null)
            {
                vector3 = colliders[i].gameObject.transform.position;
            }     
        }
        return vector3;
    }

    void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, MoveSpeed * Time.deltaTime);
        RotateBall();
        checkAndDestroy();
    }

    void RotateBall ()
    {
        diff = target - transform.position;
        diff.Normalize();
        rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
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
   
    public void checkAndDestroy ()
    {
        if (transform.position == target)
        {
            Destroy(this.gameObject);
        }
    }

    
}
