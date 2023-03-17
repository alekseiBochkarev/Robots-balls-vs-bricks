using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Battery
{
    public class BatteryEnergy : MonoBehaviour
    {
        //ToDo Add json/playerprefs saves
        [SerializeField] private bool hasEnergy = true;
        [SerializeField] private bool isActive;

        [Header("Child objects")] 
        [SerializeField] private Transform chargeIndicator;
        [SerializeField] private Transform topLeftIndicator;
        [SerializeField] private Transform topRightIndicator;

        [Header("Charge indicator sprites")] 
        [SerializeField] private Sprite dischargedIndicatorSprite;
        [SerializeField] private Sprite activeChargeIndicatorSprite;
        [SerializeField] private Sprite chargedIndicatorSprite;

        [Header("Top indicator sprites")] 
        [SerializeField] private Sprite dischargedTopIndicatorSprite;
        [SerializeField] private Sprite activeTopIndicatorSprite;
        [SerializeField] private Sprite chargedTopIndicatorSprite;

        private Image _topLeftSprite;
        private Image _topRightSprite;
        private Image _chargeIndicatorSprite;

        private void Awake()
        {
            _topLeftSprite = topLeftIndicator.GetComponent<Image>();
            _topRightSprite = topRightIndicator.GetComponent<Image>();
            _chargeIndicatorSprite = chargeIndicator.GetComponent<Image>();
        }

        public bool HasBatteryEnergy()
        {
            return hasEnergy;
        }

        public bool IsBatteryActive()
        {
            return isActive;
        }

        public void SetBatteryEnergy(bool isCharged)
        {
            hasEnergy = isCharged;
        }

        public void SetBatteryActive(bool isBatteryActive)
        {
            this.isActive = isBatteryActive;
        }

        public void SetIndicatorSprites(BatteryStates state)
        {
            if (state == BatteryStates.Discharged)
            {
                ChangeSprites(dischargedTopIndicatorSprite, dischargedIndicatorSprite);
            }

            if (state == BatteryStates.Active)
            {
                ChangeSprites(activeTopIndicatorSprite, activeChargeIndicatorSprite);
            }

            if (state == BatteryStates.Charged)
            {
                ChangeSprites(chargedTopIndicatorSprite, chargedIndicatorSprite);
            }
        }

        private void ChangeSprites(Sprite topIndicatorSprite, Sprite indicatorSprite)
        {
            _topLeftSprite.sprite = topIndicatorSprite;
            _topRightSprite.sprite = topIndicatorSprite;
            _chargeIndicatorSprite.sprite = indicatorSprite;
        }
    }
}

public enum BatteryStates
{
    Charged,
    Active,
    Discharged
}