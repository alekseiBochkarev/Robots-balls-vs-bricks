using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryEnergy : MonoBehaviour
{
    /*
    * Новая фича: Энергия от батареи.
   Суть следующая: 
   1) Каждый раз, как мы совершаем атаку -> тратится одна батарея
   2) Базовое кол-во батарей - 3
   3) Количество батарей можно увеличивать прокачкой после поражения игроком
   4) Максимальное возможное кол-во батарей - 10 (пока что) */

    //ToDo Добавить логику сохранения/загрузки данных в PlayerPrefs или Json в другом скрипте
    // Здесь должна быть логика конкретной одной батареи

    [SerializeField] private bool HasEnergy = true;
    [SerializeField] private bool IsActive = false;

    public bool HasBatteryEnergy()
    {
        return HasEnergy;
    }

    public bool IsBatteryActive()
    {
        return IsActive;
    }

    public void SetBatteryEnergy(bool IsCharged)
    {
        HasEnergy = IsCharged;
    }

    public void SetBatteryActive(bool isActive)
    {
        isActive = IsActive;
    }
}
