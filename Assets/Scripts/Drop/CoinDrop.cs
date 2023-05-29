using UnityEngine;

namespace Drop
{
    public class CoinDrop : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        private void OnEnable()
        {
            // Играть анимацию
            _animator.Play("rotation");
        }
    }
}