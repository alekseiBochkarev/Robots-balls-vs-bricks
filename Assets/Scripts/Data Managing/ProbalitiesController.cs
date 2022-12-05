using UnityEngine;

namespace Assets.Scripts.Data_Managing
{
    public class ProbalitiesController : MonoBehaviour
    {
        public static ProbalitiesController Instance;

        private void Awake()
        {
            Instance = this;
        }

        public float GetCalculatedValueFromTotalByPercentage(float _totalValue, float _percentageOfTotalValue)
        {
            float valueAfterCalculation = _percentageOfTotalValue * _totalValue / 100f;
            //Debug.Log("Total Value -> " + _totalValue + " <- in percentage -> " + _percentageOfTotalValue + " <- equals ---> " + valueAfterCalculation);
            return valueAfterCalculation;
        }

        public bool CheckProbality(float _percentage)
        {
            float randomValue = Random.Range(0, 101);
            return randomValue <= _percentage;
        }
    }
}