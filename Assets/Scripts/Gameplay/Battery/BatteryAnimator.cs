using UnityEngine;

namespace Gameplay.Battery
{
    public class BatteryAnimator : MonoBehaviour
    {
        private const string HasEnergy = "HasEnergy";
        private static readonly int HasEnergy1 = Animator.StringToHash(HasEnergy);

        [SerializeField] private BatteryEnergy batteryEnergy;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetBool(HasEnergy1, batteryEnergy.HasBatteryEnergy());
        }
    }
}
