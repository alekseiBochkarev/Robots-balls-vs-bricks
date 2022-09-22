using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Combo
{
    public class ComboLauncher : MonoBehaviour
    {
        public static ComboLauncher Instance;
        [SerializeField] List<ComboAttackSO> comboAttacks;
        private GameObject m_ComboPrefab;
        private Vector3 cannonPosition = new Vector3(2f, -6.09f, 0f); //need to add cannon position instead hardcore

        private void Awake()
        {
            Instance = this;
        }

        public void AddComboPoint()
        {
            int currentComboAmount = ComboCounter.GetComboAmount();
            if (currentComboAmount != 0)
            {
                for (int i = 0; i < comboAttacks.Count; i++)
                {
                    if (currentComboAmount % comboAttacks[i].initComboOnValue == 0)
                    {
                        m_ComboPrefab = Resources.Load<GameObject>("ComboAttacks/" + comboAttacks[i].comboType.ToString());
                        Instantiate(m_ComboPrefab, cannonPosition, Quaternion.identity);
                    }

                }
            }
        }

        public void SetSpecialAttack(SpecialAttackSO specialAttack)
        {
            comboAttacks.Add( (ComboAttackSO) specialAttack);
        }
    }
    public enum ComboAttackEnum
    {
        FireCombo,
        IceCombo,
        LightningCombo,
        RocketCombo
    }
}