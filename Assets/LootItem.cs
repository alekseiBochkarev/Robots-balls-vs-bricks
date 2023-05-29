using Assets.Scripts.Data_Managing;
using Assets.Scripts.DataManaging.Utills;
using UnityEngine;

public class LootItem : MonoBehaviour
{
    private const float VECTOR3_X_MAX = 3f;
    private const float VECTOR3_Y_MAX = 1.5f;
    private const float DISAPPEAR_TIMER_MAX = 2f;
    private float _disappearTimer = DISAPPEAR_TIMER_MAX;
    private Vector3 _moveVector;
    private Vector3 _moveItemToTarget;

    [SerializeField] private int moveSpeed = 10;
    public LootSO lootSo;

    [Header("Up And Down Animation Vars")] 
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;
    
    private Vector3 _posOrigin;
    private Vector3 _temPos;
    private readonly float _decreaseScaleAmount = 0.05f;


    private void Awake()
    {
        _moveVector = Utills.GetRandomVector(VECTOR3_X_MAX, VECTOR3_Y_MAX);
        _posOrigin = transform.position;

        amplitude = 0.1f;
        frequency = 0.8f;
    }

    private Vector3 GetHeroPosition()
    {
        return Hero.Instance.transform.position;
    }

    private void Update()
    {
        _moveItemToTarget = GetHeroPosition();
        DropLootAnimation();
        PlayHoverUpDownAnim();
        if (_disappearTimer <= 0)
        {
            GetLoot();
        }
    }

    private void DropLootAnimation()
    {
        _disappearTimer -= Time.deltaTime;
        if (_disappearTimer > 0)
        {
            transform.position += _moveVector * Time.deltaTime; // changes position of Loot
            _moveVector -= _moveVector * 0.1f * Time.deltaTime;
        }
    }

    private void PlayHoverUpDownAnim()
    {
        _disappearTimer -= Time.deltaTime;
        if (_disappearTimer > 0)
        {
            _temPos = _posOrigin;
            _temPos.y += (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency)) * amplitude;
            transform.position = _temPos;
        }
    }

    private void GetLoot()
    {
        // Move position to hero with scale down
        if (transform.localScale is { x: > 0, y: > 0, z: > 0 })
        {
            transform.localScale -= Vector3.one * _decreaseScaleAmount * Time.deltaTime;
        }

        transform.position = Vector3.MoveTowards(transform.position, _moveItemToTarget, moveSpeed * Time.deltaTime);

        if (transform.position == _moveItemToTarget)
        {
            if (lootSo.GetType() == typeof(CoinLootSO))
            {
                WalletController.Instance.AddMoneyAndShow(lootSo.dropLootQuantity);
            }

            if (lootSo.GetType() == typeof(HealLootSO))
            {
                float healAfterCalculations =
                    ProbalitiesController.Instance.GetCalculatedValueFromTotalByPercentage(Hero.Instance.MaxHealth,
                        lootSo.dropLootQuantity);
                Hero.Instance.HealUp(healAfterCalculations);
            }

            // Destroy object after it reaches position
            Destroy(this.gameObject);
        }
    }
}