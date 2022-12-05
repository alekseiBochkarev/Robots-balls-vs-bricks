using Assets.Scripts.Data_Managing;
using Assets.Scripts.DataManaging.Utills;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour
{
    private const float VECTOR3_X_MAX = 3f;
    private const float VECTOR3_Y_MAX = 1.5f;
    private const float DISAPPEAR_TIMER_MAX = 2f;
    private float disappearTimer = DISAPPEAR_TIMER_MAX;
    private Vector3 moveVector;
    private Vector3 moveItemToTarget;

    public int MoveSpeed = 10;

    public LootSO lootSO;

    public float itemQuantity;

    [Header("Up And Down Animation Vars")]
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;
    Vector3 posOrigin = new Vector3();
    Vector3 temPos = new Vector3();


    private void Awake()
    {
        moveVector = Utills.GetRandomVector(VECTOR3_X_MAX, VECTOR3_Y_MAX);
        posOrigin = transform.position;

        moveItemToTarget = Hero.Instance.transform.position;

        amplitude = 0.1f;
        frequency = 0.8f;
    }
    private void Update()
    {
        DropLootAnimation();
        PlayHoverUpDownAnim();
        if (disappearTimer <= 0)
        {
            GetLoot();
        }
    }

    private void DropLootAnimation()
    {
        disappearTimer -= Time.deltaTime;
        if (disappearTimer > 0)
        {
            transform.position += moveVector * Time.deltaTime; // changes position of Loot
            moveVector -= moveVector * 0.1f * Time.deltaTime;
        }
    }

    private void PlayHoverUpDownAnim()
    {
        disappearTimer -= Time.deltaTime;
        if (disappearTimer > 0)
        {
            temPos = posOrigin;
        temPos.y += (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency)) * amplitude;
        transform.position = temPos;
        }
    }

    public void GetLoot()
    {
        // Move position to hero with scale down
        float decreaseScaleAmount = 0.05f;
        if (transform.localScale.x > 0 && transform.localScale.y > 0 && transform.localScale.z > 0)
        {
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }
        transform.position = Vector3.MoveTowards(transform.position, moveItemToTarget, MoveSpeed * Time.deltaTime);

        if (transform.position == moveItemToTarget)
        {
            if (lootSO.GetType() == typeof(CoinLootSO))
            {
                WalletController.Instance.AddMoneyAndShow(lootSO.dropLootQuantity);
            }
            if (lootSO.GetType() == typeof(HealLootSO))
            {
                float healAfterCalculations = ProbalitiesController.Instance.GetCalculatedValueFromTotalByPercentage(Hero.Instance.MaxHealth, lootSO.dropLootQuantity);
                Hero.Instance.HealUp(healAfterCalculations);
            }
            // Destroy object after it reaches position
            Destroy(this.gameObject);
        }
    }

}
