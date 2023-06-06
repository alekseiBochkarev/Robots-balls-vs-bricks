using UnityEngine;

namespace Animation
{
    public class UpAndDownAnimation : MonoBehaviour
    {
        [Header("Up And Down Animation Vars")] 
        [SerializeField] private float amplitude;
        [SerializeField] private float frequency;
        private Vector3 _posOrigin;
        private Vector3 _temPos;

        private void Awake()
        {
            _posOrigin = transform.position;

            // Set default values for vars
            amplitude = 0.02f;
            frequency = 1f;
        }

        private void Update()
        {
            PlayHoverUpDownAnim();
        }

        private void PlayHoverUpDownAnim()
        {
            _temPos = _posOrigin;
            _temPos.y += (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency)) * amplitude;
            transform.position = _temPos;
        }
    }
}