using System;
using System.ComponentModel;
using UnityEngine;

namespace Gameplay.Batteries.Battery_Cell
{
    public class BatteryCellController : MonoBehaviour
    {
        /**
     * Для отображения корректного спрайта ячеек нужно просчитать в процентах от MaxBatteryAmount
     * Зеленые ячейки - 68-100%
     * Желтые ячейки 34-67%
     * Красные ячейки 1-33%
     */
        private GameObject _cellPrefab;

        private const int BaseBatteryCellsAmount = 3;
        private const int MaxBatteryCellsAmount = 12;

        [SerializeField] private int batteryCellsAmount;
        [SerializeField] private double activeCellsPercentage;

        private readonly string _batteryCellsAmountString = "batteryCellsAmount";
        private GameObject[] _cells;

        [Header("Cells Colors Display Percentages")]
        // Red Cells
        private const double RedMinPercentage = 1;

        private const double RedMaxPercentage = 33;

        // Yellow Cells
        private const double YellowMinPercentage = 34;
        private const double YellowMaxPercentage = 67;

        // Green Cells
        private const double GreenMinPercentage = 68;
        private const double GreenMaxPercentage = 100;


        /**
        * при Awake загружаем количество доступных ячеек и отображаем их
        */
        public void Awake()
        {
            _cellPrefab = Resources.Load<GameObject>("Cell");
            LoadAndShowBatteryCells();
        }

        public void LoadAndShowBatteryCells()
        {
            LoadBatteryCellsAmount();
            ShowBatteryCells();
        }

        public void AddCell()
        {
            if (batteryCellsAmount < MaxBatteryCellsAmount)
            {
                SpawnCell();

                batteryCellsAmount++;
                SaveBatteryCellsAmount();
                ShowBatteryCells();
            }
        }

        private void LoadBatteryCellsAmount()
        {
            batteryCellsAmount = PlayerPrefs.GetInt(_batteryCellsAmountString);
            if (batteryCellsAmount != 0)
            {
                if (batteryCellsAmount > MaxBatteryCellsAmount)
                {
                    batteryCellsAmount = MaxBatteryCellsAmount;
                    SaveBatteryCellsAmount();
                }
            }
            else
            {
                batteryCellsAmount = BaseBatteryCellsAmount;
                SaveBatteryCellsAmount();
            }
        }

        private void SaveBatteryCellsAmount()
        {
            Debug.Log(_batteryCellsAmountString + " is -> " + batteryCellsAmount);
            if (batteryCellsAmount <= MaxBatteryCellsAmount)
            {
                if (batteryCellsAmount > MaxBatteryCellsAmount)
                {
                    batteryCellsAmount = MaxBatteryCellsAmount;
                }

                PlayerPrefs.SetInt(_batteryCellsAmountString, batteryCellsAmount);
            }
        }

        /**
         * Получаем все ячейки батареи и меняем у них спрайт в зависимости от процента
         */
        private void ShowBatteryCells()
        {
            SpawnCells();
            _cells = GetCells();
            if (_cells.Length == 0) return;
            activeCellsPercentage = CalculateCellsFillPercentage();
            Debug.Log("activeCellsPercentage is -> " + activeCellsPercentage);

            var color = CalculateCellColor();
            ChangeCellsSprites(color);
        }

        private BatteryCellColors CalculateCellColor()
        {
            if (activeCellsPercentage <= RedMaxPercentage)
            {
                return BatteryCellColors.Red;
            }

            if (activeCellsPercentage is >= YellowMinPercentage and <= YellowMaxPercentage)
            {
                return BatteryCellColors.Yellow;
            }

            if (activeCellsPercentage is >= GreenMinPercentage and <= GreenMaxPercentage)
            {
                return BatteryCellColors.Green;
            }

            throw new InvalidOperationException();
        }

        private void SpawnCells()
        {
            _cells = GetCells();
            var batteryCellsQuantity = batteryCellsAmount;
            if (_cells.Length == batteryCellsQuantity) return;
            for (var i = _cells.Length; i < batteryCellsQuantity; i++)
            {
                SpawnCell();
            }
        }

        /**
         * Сбрасывает и удаляет прокачанные ячейки батареи до базового значения BaseBatteryCellsAmount
         */
        public void ResetAdditionalCells()
        {
            _cells = GetCells();
            switch (_cells.Length)
            {
                case BaseBatteryCellsAmount:
                    return;
                case 0:
                    batteryCellsAmount = BaseBatteryCellsAmount;
                    break;
                default:
                    var batteryCellsQuantity = batteryCellsAmount;
                    for (var i = batteryCellsQuantity; i > BaseBatteryCellsAmount; i--)
                    {
                        //Destroy(_cells[i - 1]);
                        DestroyImmediate(_cells[i - 1]);
                    }
                    batteryCellsAmount = BaseBatteryCellsAmount;
                    break;
            }
            SaveBatteryCellsAmount();
            ShowBatteryCells();
        }

        /**
         * Получает все существующие ячейки на сцене с тегом 'Cell'
         */
        private static GameObject[] GetCells()
        {
            var array = GameObject.FindGameObjectsWithTag("Cell");
            Debug.Log("Size of Cells array is -> " + array.Length);
            return array;
        }

        /**
         * Создает ячейку внутри батареи и меняет всем ячейкам спрайт в зависимости от процентного соотношения
         */
        private void SpawnCell()
        {
            Debug.Log("SpawnCell");
            Debug.Log(batteryCellsAmount < MaxBatteryCellsAmount);
            Debug.Log("batteryCellsAmount is -> " + batteryCellsAmount);
            Debug.Log("MaxBatteryCellsAmount is -> " + MaxBatteryCellsAmount);

            // Define background parent  and set it for new cell
            var _instance = Instantiate(_cellPrefab, this.transform, true);

            ChangeCellSprite(CalculateCellColor(), _instance);
        }

        private void ChangeCellsSprites(BatteryCellColors cellColor)
        {
            _cells = GetCells();
            foreach (var cell in _cells)
            {
                ChangeCellSprite(cellColor, cell);
            }
        }

        private void ChangeCellSprite(BatteryCellColors cellColor, GameObject cell)
        {
            if (!Enum.IsDefined(typeof(BatteryCellColors), cellColor))
                throw new InvalidEnumArgumentException(nameof(cellColor), (int)cellColor,
                    typeof(BatteryCellColors));

            Debug.Log("Change color to next cell -> " + cell);
            cell.GetComponent<BatteryCell>().ChangeCellColor(cellColor);
        }

        private double CalculateCellsFillPercentage()
        {
            return Math.Round(batteryCellsAmount / (double)MaxBatteryCellsAmount * 100);
        }
    }
}