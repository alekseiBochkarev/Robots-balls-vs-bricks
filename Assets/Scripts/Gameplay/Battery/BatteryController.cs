using TMPro;
using UnityEngine;

namespace Gameplay.Battery
{
    public class BatteryController : MonoBehaviour
    {
        [Header("Settings")] 
        private const int BaseBatteryAmount = 3;
        private const int MaxBatteryAmount = 10;

        [SerializeField] private int batteriesAmount;
        [SerializeField] private TextMeshProUGUI counterText;
        [SerializeField] private BatteryEnergy batteryEnergy;

        public void Awake()
        {
            if (batteriesAmount == 0)
            {
                batteriesAmount = BaseBatteryAmount;
            }
            ShowCounterText();
        }

        private void ShowCounterText()
        {
            counterText.text = batteriesAmount.ToString();
        }

        public void DischargeTheBattery()
        {
            batteryEnergy.SetBatteryActive(false);
            batteryEnergy.SetBatteryEnergy(false);

            ShowCounterText();

            batteryEnergy.SetIndicatorSprites(BatteryStates.Discharged);
        }

        public void ChargeTheBattery()
        {
            if (batteriesAmount > 0 && !batteryEnergy.IsBatteryActive())
            {
                batteryEnergy.SetBatteryEnergy(true);
                batteryEnergy.SetBatteryActive(false);

                batteriesAmount--;
                ShowCounterText();

                batteryEnergy.SetIndicatorSprites(BatteryStates.Charged);
            }
        }

        public void ActivateTheBattery()
        {
            if (batteryEnergy.HasBatteryEnergy())
            {
                batteryEnergy.SetBatteryActive(true);

                batteryEnergy.SetIndicatorSprites(BatteryStates.Active);
            }
        }

        public void AddAdditionalBattery()
        {
            if (batteriesAmount != MaxBatteryAmount)
            {
                batteriesAmount++;
                ShowCounterText();
            }
        }

        public void ClearAdditionalBatteries()
        {
            if (batteriesAmount != BaseBatteryAmount)
            {
                batteriesAmount = BaseBatteryAmount;
                ShowCounterText();
            }
        }

        private void Update()
        {
            //For Debug
            if (Input.GetKeyDown(KeyCode.T))
            {
                AddAdditionalBattery();
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                ClearAdditionalBatteries();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                DischargeTheBattery();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                ChargeTheBattery();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                ActivateTheBattery();
            }
        }
    }
}
   