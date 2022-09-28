﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay.HeroBuffs
{
    public class HeroBuffs : MonoBehaviour
    {
        public static HeroBuffs Instance;

        [Header("List of current HeroBuffsSO")]
        [SerializeField] List<HeroBuffSO> heroBuffs;
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            /* It needs to initialize if a hero already have buffs
               otherwise -> it will not load all buffs
            */
            if (heroBuffs != null)
            {
                foreach (var singleHeroBuff in heroBuffs)
                {
                    CallOnHeroBuffAddedEvent(singleHeroBuff);
                }
            }
        }
        public void SetHeroBuff(SpecialAttackSO _specialAttack)
        {
            heroBuffs.Add( (HeroBuffSO) _specialAttack);
            CallOnHeroBuffAddedEvent( (HeroBuffSO) _specialAttack);
        }

        private void CallOnHeroBuffAddedEvent(HeroBuffSO _heroBuffSO)
        {
            EventManager.OnHeroBuffAdded(_heroBuffSO);
        }

    }
    public enum HeroBuffsEnum
    {
        DoubleComboBuff,
        DiscountComboBuff,
        IncreasedCountComboBuff,
        HeroIncreasedHealthBuff,
        HeroInvulnerabilityBuff,
        HeroExtraLifeBuff
    }
}