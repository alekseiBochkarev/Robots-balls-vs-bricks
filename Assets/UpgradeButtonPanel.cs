using UnityEngine;

public class UpgradeButtonPanel : MonoBehaviour
{
    /**
     * Данный класс будет отвечать за отображение информации о стате героя, а также его прокачки через кнопку:
     * 1) При отображении панели загружается панель, в которой будет префаб того, что качаем, название и цена
     * 2) Определить единственный метод прокачки, который будет принимать в себя Transform/Gameobject, внутри него будет
     * зашит метод типа Upgrade, к которому и будет идти обращение
     * 3) Все префабы интерактивные, чтобы наглядно показать прокачку героя
     */
    [SerializeField] private Transform statObject;

    private string statNameText;
    private string upgradePrice;

    private void UpgradeStat()
    {
       // statObject.gameObject.TryGetComponent()
    }
}