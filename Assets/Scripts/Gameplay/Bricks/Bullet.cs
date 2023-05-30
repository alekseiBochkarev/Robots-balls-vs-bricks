using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public GameObject hero;
    [SerializeField] private int attackPower;

    public int AttackPower
    {
        get => attackPower;
        set => attackPower = value;
    }

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
        hero = GameObject.Find("Hero");
        damageTextColor = TextController.COLOR_BLACK;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
        target = FindGoalToMove();
    }

    public Vector3 FindGoalToMove()
    {
        return hero.transform.position;
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

    public void DestroyBall () {
        Destroy(this.gameObject);
    }

    
}
