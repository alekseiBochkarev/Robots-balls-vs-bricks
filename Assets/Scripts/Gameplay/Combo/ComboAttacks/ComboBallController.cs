using Assets.Scripts.Gameplay.Combo;
using Assets.Scripts.DataManaging.Utills;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComboBallController : MonoBehaviour, IBall
{
    public GameObject hero;
    public int attackPower;
    private int damageTextFontSize;
    private Color damageTextColor;
    private float vision;
    private readonly int _moveSpeed = 10;
    private GameObject brickObject;
    private Transform cannonPosition;
    Vector3 diff;
    float rot_z;
    [SerializeField] private CloneBallTypes ballToSpawnOnHit;

    private CircleCollider2D m_Collider2D;

    private void OnEnable()
    {
        //Debug.Log("combo ball enabled -> add combo amount on scene");
        cannonPosition = GameObject.Find("Cannon").transform;
        brickObject = FindBrickToMove();
        ComboLauncher.Instance.AddComboAmountOnScene();

        hero = GameObject.Find("Hero");
        m_Collider2D = GetComponent<CircleCollider2D>();
        DisablePhysics();

        attackPower = hero.GetComponent<Hero>().attackSkill;
        damageTextColor = TextController.COLOR_YELLOW;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }

    private void OnDisable() {
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
        if (brickObject != null)
        {
            if (brickObject.GetComponent<Brick>() != null)
            {
                if (brickObject.GetComponent<Brick>().MCurrentBrickHealth > 0)
                {
                    transform.position = Vector3.MoveTowards(transform.position, brickObject.transform.position, _moveSpeed * Time.deltaTime);
                    RotateBall();
                    CheckAndDestroy();
                }
                else
                {
                    brickObject = FindBrickToMove();
                }
            }
            else
            {
                HideComboAttack();
            }
        }
        else
        {
            brickObject = FindBrickToMove();
        }
    }

    void RotateBall()
    {
        diff = brickObject.transform.position - transform.position;
        diff.Normalize();
        rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    public void CheckAndDestroy()
    {
        if (transform.position == brickObject.transform.position)
        {
            if (CloneBallTypes.InstaKillBall == ballToSpawnOnHit)
            {
                string instaKillMessageText = "INSTAKILL";
                InstaKillAttack instaKillAttack = new InstaKillAttack(instaKillMessageText);
                instaKillAttack.SpecialAttack(brickObject.transform.position, brickObject);
            }

            if (CloneBallTypes.RocketClone != ballToSpawnOnHit && CloneBallTypes.InstaKillBall != ballToSpawnOnHit)
            {
                GameObject ballPrefab = Resources.Load<GameObject>(ballToSpawnOnHit.ToString());
                GameObject ballPrefabToSpawn = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                brickObject.GetComponent<Brick>().TakeDamage(attackPower, damageTextColor, damageTextFontSize);
            }
            HideComboAttack();
        }
    }

    public void DestroyBall () {
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
}

public enum CloneBallTypes
{
    LaserHorizontalCloneBall,
    LaserVerticalCloneBall,
    LaserCrossCloneBall,
    RocketClone,
    InstaKillBall
}
