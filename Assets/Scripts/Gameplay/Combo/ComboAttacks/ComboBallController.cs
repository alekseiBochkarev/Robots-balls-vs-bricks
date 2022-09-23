using Assets.Scripts.Gameplay.Combo;
using UnityEngine;

public class ComboBallController : MonoBehaviour
{
    public GameObject hero;
    public int attackPower;
    private int damageTextFontSize;
    private Color damageTextColor;
    private float vision;
    Collider2D[] colliders;
    public int MoveSpeed = 7;
    GameObject brickObject;
    Vector3 diff;
    float rot_z;
    [SerializeField] private CloneBallTypes ballToSpawnOnHit;

    private CircleCollider2D m_Collider2D;

    void Start()
    {
        brickObject = FindGoalToMoveAsInstanceID();
        ComboLauncher.Instance.AddComboAmountOnScene();

        hero = GameObject.Find("Hero");
        m_Collider2D = GetComponent<CircleCollider2D>();
        DisablePhysics();

        attackPower = hero.GetComponent<Hero>().attackSkill;
        damageTextColor = TextController.COLOR_YELLOW;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    }


    public GameObject FindGoalToMoveAsInstanceID()
    {
        vision = 10f;
        GameObject brickObject = null;
        colliders = Physics2D.OverlapCircleAll(transform.position, vision);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject == gameObject) continue;
            if (colliders[i].gameObject.GetComponent<Brick>() != null)
            {
                brickObject = colliders[i].gameObject;
                break;
            }
        }
        return brickObject;
    }


    void Update()
    {
        if (brickObject.activeSelf == false || brickObject == null)
        {
            brickObject = FindGoalToMoveAsInstanceID();
            if (brickObject == null)
            {
                ComboLauncher.Instance.DecreaseComboAmountOnScene();
                Destroy(this.gameObject);
            }
        }
        if (brickObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, brickObject.transform.position, MoveSpeed * Time.deltaTime);
            RotateBall();
            CheckAndDestroy();
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
            if (CloneBallTypes.RocketClone != ballToSpawnOnHit)
            {
                GameObject ballPrefab = Resources.Load<GameObject>(ballToSpawnOnHit.ToString());
                GameObject ballPrefabToSpawn = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                brickObject.GetComponent<Brick>().TakeDamage(attackPower, damageTextColor, damageTextFontSize);
            }
            ComboLauncher.Instance.DecreaseComboAmountOnScene();
            Destroy(this.gameObject);
        }
    }
    public void DisablePhysics()
    {
        m_Collider2D.enabled = false;
    }
}

public enum CloneBallTypes
{
    LaserHorizontalCloneBall,
    LaserVerticalCloneBall,
    LaserCrossCloneBall,
    RocketClone
}
