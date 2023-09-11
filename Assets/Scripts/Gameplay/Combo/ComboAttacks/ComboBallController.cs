using System;
using Assets.Scripts.Gameplay.Combo;
using Assets.Scripts.DataManaging.Utills;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComboBallController : MonoBehaviour //, IBall
{
    public ComboAttackBehaviour comboAttackBehaviour;
    [SerializeField] protected GameObject hero;
    [SerializeField] private int attackPower;
    private int damageTextFontSize;
    private Color damageTextColor;

    public int AttackPower
    {
        get => attackPower;
        set => attackPower = value;
    }
    
    public int DamageTextFontSize
    {
        get => damageTextFontSize;
        set => damageTextFontSize = value;
    }

    public Color DamageTextColor
    {
        get => damageTextColor;
        set => damageTextColor = value;
    }


    private float vision;
    private readonly int _moveSpeed = 10;
    private GameObject brickObject;
    private Vector3 target;
    private Transform cannonPosition;
    Vector3 diff;
    float rot_z;
 //   [SerializeField] private CloneBallTypes ballToSpawnOnHit;

    private CircleCollider2D m_Collider2D;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        //Debug.Log("combo ball enabled -> add combo amount on scene");
        cannonPosition = GameObject.Find("Cannon").transform;
        brickObject = FindBrickToMove();
        target = brickObject.transform.position;
       // ComboLauncher.Instance.AddComboAmountOnScene();

        hero = GameObject.Find("Hero");
        m_Collider2D = GetComponent<CircleCollider2D>();
        DisablePhysics();
        attackPower = hero.GetComponent<Hero>().AttackSkill;
        damageTextColor = TextController.COLOR_YELLOW;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }
    

    private void OnDisable()
    {
        ComboLauncher.Instance.DecreaseComboAmountOnScene();
    }

    public GameObject FindBrickToMove()
    {
        vision = 10f;
        List<Collider2D> activeBricks = Physics2D.OverlapCircleAll(transform.position, vision).ToList();
        activeBricks.RemoveAll(el => !el.gameObject.GetComponent<Brick>());
        if (activeBricks.Count != 0 && activeBricks != null)
        {
            if (activeBricks.Count == 1)
            {
                brickObject = activeBricks[0].gameObject;
            }
            else
            {
                Utills utills = new Utills();
                utills.Shuffle(activeBricks);
                brickObject = activeBricks[0].gameObject;
            }
        }
        else
        {
            brickObject = GameObject.Find("topBorder");
        }

        return brickObject;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _moveSpeed * Time.deltaTime);
        RotateBall();
        CheckAndDestroy();
    }

    void RotateBall()
    {
        diff = target - transform.position;
        diff.Normalize();
        rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    public void ComboAttack(Vector3 position, GameObject brick)
    {
        if (brick != null)
        {
            comboAttackBehaviour.ComboAttack(position, brick);
        }
    }

    public void CheckAndDestroy()
    {
        if (brickObject != null)
        {
            if (transform.position == target)
            {
                ComboAttack(target, brickObject);
                HideComboAttack();
            }
        }
        else
        {
            HideComboAttack();
        }
    }

    public void DestroyBall()
    {
        HideComboAttack();
    }

    private void HideComboAttack() // needs to hide, if we want reuse this gameObject using ObjectPool
    {
        //ComboLauncher.Instance.DecreaseComboAmountOnScene();
        this.transform.position = cannonPosition.position;
        this.transform.rotation = Quaternion.identity;
        this.gameObject.SetActive(false);
    }

    private void DisablePhysics()
    {
        m_Collider2D.enabled = false;
    }

}

public enum CloneBallTypes
{
    LaserHorizontalCloneBall,
    LaserVerticalCloneBall,
    LaserCrossCloneBall,
    RocketClone,
    InstaKillBall
}