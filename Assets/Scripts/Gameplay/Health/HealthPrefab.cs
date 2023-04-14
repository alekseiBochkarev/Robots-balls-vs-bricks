using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Health
{
    public class HealthPrefab : MonoBehaviour
    {
        /**
         * HealthPrefab содержит в себе логику изменения спрайта в зависимости от уровня
        */
        [SerializeField] private Sprite[] sprites;

        private Image _healthPrefabSprite;

        private void Start()
        {
            _healthPrefabSprite = transform.GetComponent<Image>();
            LoadSprites();
        }

        public void ChangeHealthSprite(int level)
        {
            _healthPrefabSprite.sprite = sprites[level];
        }

        private void LoadSprites()
        {
            var loadedSprites = Resources.LoadAll("HealthPrefabSprites", typeof(Sprite));
            sprites = new Sprite[loadedSprites.Length];

            for (var x = 0; x < loadedSprites.Length; x++)
            {
                sprites[x] = (Sprite)loadedSprites[x];
            }
            Debug.Log("Sprites for health are loaded -> " + sprites);
        }
    }
}