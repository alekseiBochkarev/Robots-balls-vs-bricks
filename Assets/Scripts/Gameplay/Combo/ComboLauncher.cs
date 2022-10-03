using Assets.Scripts.Data_Managing;
using Assets.Scripts.Gameplay.HeroBuffs;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Combo
{
    public class ComboLauncher : MonoBehaviour
    {
        public static ComboLauncher Instance;

        [Header("List of Combos")]
        [SerializeField] List<ComboAttackSO> comboAttacks;
        private GameObject m_ComboPrefab;
        private Vector3 cannonPosition = new Vector3(2f, -6.09f, 0f); //need to add cannon position instead hardcore
        public bool CanPlay { set; get; }
        public int comboAmountOnScenes;
        private int currentComboAmount;
        private int initComboOnValue;

        [Header("Double Combo Info")]
        [SerializeField] private float PercentageToTriggerComboTwice;
        [SerializeField] private bool IsDoubleComboBuffActivated;
        [SerializeField] private bool IsPossibleToDoubleAttack;

        [Header("Discount Combo Info")]
        [SerializeField] private bool IsDiscountComboBuffActivated;
        [SerializeField] private float PercentageToSetComboDiscount;

        private void Awake()
        {
            Instance = this;
            CanPlay = true;
            IsDoubleComboBuffActivated = false;
            IsDiscountComboBuffActivated = false;
            EventManager.HeroBuffAdded += InitComboBuffs;
            EventManager.ComboCounterChanged += AddComboPointAndStartComboAttack;
        }
        private void OnDestroy()
        {
            EventManager.HeroBuffAdded -= InitComboBuffs;
            EventManager.ComboCounterChanged -= AddComboPointAndStartComboAttack;
        }

        private void Update()
        {
            if (comboAmountOnScenes == 0)
            {
                CanPlay = true;
                comboAmountOnScenes = 0;
            }
        }

        private void InitComboBuffs(HeroBuffSO heroBuff)
        {
            InitDoubleComboBuff(heroBuff);
            InitDiscountComboBuff(heroBuff);
        }

        private void InitDoubleComboBuff(HeroBuffSO buff)
        {

            Debug.Log("InitDoubleComboBuff BEFORE IF");
            if (buff.heroBuffType.Equals(HeroBuffsEnum.DoubleComboBuff))
            {
                IsDoubleComboBuffActivated = true;
                PercentageToTriggerComboTwice = (float) buff.heroBuffValue;
                Debug.Log("InitDoubleComboBuff AFTER IF");
            }
        }

        private void InitDiscountComboBuff(HeroBuffSO buff)
        {

            Debug.Log("InitDiscountComboBuff BEFORE IF");
            if (buff.heroBuffType.Equals(HeroBuffsEnum.DiscountComboBuff))
            {
                IsDiscountComboBuffActivated = true;
                PercentageToSetComboDiscount = (float) buff.heroBuffValue;
                Debug.Log("InitDiscountComboBuff AFTER IF");
            }
        }

        public void DecreaseComboAmountOnScene()
        {
            comboAmountOnScenes--;
        }

        public void AddComboAmountOnScene()
        {
            comboAmountOnScenes++;
        }

        private void SetCurrentComboAmount(int _currentComboAmount)
        {
            this.currentComboAmount = _currentComboAmount;
        }

        public void AddComboPointAndStartComboAttack(int _currentComboAmount)
        {
            SetCurrentComboAmount(_currentComboAmount);
            if (currentComboAmount != 0 && comboAttacks.Count != 0)
            {
                for (int i = 0; i < comboAttacks.Count; i++)
                {
                    initComboOnValue = comboAttacks[i].initComboOnValue;
                    if (IsDiscountComboBuffActivated)
                    {
                        initComboOnValue = (int) ProbalitiesController.Instance.GetCalculatedValueFromTotalByPercentage(initComboOnValue, PercentageToSetComboDiscount);
                    }
                    if (currentComboAmount % initComboOnValue == 0)
                    {
                        m_ComboPrefab = Resources.Load<GameObject>("ComboAttacks/" + comboAttacks[i].comboType.ToString());
                        if (IsDoubleComboBuffActivated == true)
                        {
                            IsPossibleToDoubleAttack = ProbalitiesController.Instance.CheckProbality(PercentageToTriggerComboTwice);
                            Debug.Log("IsPossibleToDoubleAttack -> " + IsPossibleToDoubleAttack);
                            if (IsPossibleToDoubleAttack == true)
                            {
                                Instantiate(m_ComboPrefab, cannonPosition, Quaternion.identity);
                            }
                        }
                        Instantiate(m_ComboPrefab, cannonPosition, Quaternion.identity);
                        CanPlay = false;
                    }
                }
            }
        }

        public void SetSpecialAttack(SpecialAttackSO _specialAttack)
        {
            comboAttacks.Add( (ComboAttackSO) _specialAttack);
        }
    }
    public enum ComboAttackEnum
    {
        RocketCombo,
        FireCombo,
        IceCombo,
        BombCombo,
        LightningCombo,
        InstaKillCombo,
        BlackHoleCombo,
        LaserVerticalCombo,
        LaserHorizontalCombo,
        LaserCrossCombo
    }
}