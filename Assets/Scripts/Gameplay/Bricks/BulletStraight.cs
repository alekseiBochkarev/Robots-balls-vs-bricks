using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class BulletStraight : MonoBehaviour
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
    [SerializeField] private int moveSpeed;
    
    public int MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }
    public bool isSlow;
    Vector3 target;
    Vector3 diff;
    float rot_z;
    

    void Start ()
    {
        hero = GameObject.Find("Hero");
        damageTextColor = TextController.COLOR_BLACK;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
        //target = FindGoalToMove();
        checkAndDestroy();
    }

    public Vector3 FindGoalToMove()
    {
        Vector3 targetNew = new Vector3(transform.position.x, hero.transform.position.y, transform.position.z); 
        return hero.transform.position;
    }

    void Update ()
    {
        transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
     //   RotateBall();
        
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
       Destroy(this.gameObject, 1);
    }

    public void DestroyBall () {
        Destroy(this.gameObject);
    }

    
}
