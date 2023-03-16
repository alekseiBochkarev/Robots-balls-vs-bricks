using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int BASE_BATTERY_AMOUNT = 3;
    [SerializeField] private int MAX_BATTERY_AMOUNT = 10;

    [SerializeField] private int batteriesAmount;
    [SerializeField] private GameObject batteryPrefab;
    [SerializeField] private GameObject batteryGameObject;

    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private BatteryEnergy batteryEnergy;

    public void Awake()
    {
        if (batteriesAmount == 0)
        {
            batteriesAmount = BASE_BATTERY_AMOUNT;
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

        batteryEnergy.SetIndicatorSprites(BatteryStates.DISCHARGED);

    }

    public void ChargeTheBattery()
    {
        if (batteriesAmount > 0 && !batteryEnergy.IsBatteryActive())
        {
            batteryEnergy.SetBatteryEnergy(true);
            batteryEnergy.SetBatteryActive(false);

            batteriesAmount--;
            ShowCounterText();

            batteryEnergy.SetIndicatorSprites(BatteryStates.CHARGED);
        }
    }

    public void ActivateTheBattery()
    {
        if (batteryEnergy.HasBatteryEnergy())
        {
            batteryEnergy.SetBatteryActive(true);

            batteryEnergy.SetIndicatorSprites(BatteryStates.ACTIVE);
        }
    }

    public void AddAdditionalBattery()
    {
        if (batteriesAmount != MAX_BATTERY_AMOUNT)
        {
            batteriesAmount++;
            ShowCounterText();
        }
    }

    public void ClearAdditionalBatteries()
    {
        if (batteriesAmount != BASE_BATTERY_AMOUNT)
        {
            batteriesAmount = BASE_BATTERY_AMOUNT;
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
   