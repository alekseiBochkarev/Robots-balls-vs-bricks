using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.StatsPanel
{
    public abstract class AbstractStatPrefab : MonoBehaviour
    {
        /**
        * AbstractStatPrefab содержит в себе логику изменения спрайта в зависимости от уровня прокачки статов
        */
        [SerializeField] private Sprite[] sprites;

        private Image _spriteImage;

        private void Start()
        {
            _spriteImage = transform.GetComponent<Image>();
        }
    
        public void ChangeSprite(int level)
        {
            _spriteImage.sprite = sprites[level - 1];
        }

        public void LoadSprites(string pathToSprites)
        {
            var loadedSprites = Resources.LoadAll(pathToSprites, typeof(Sprite));
            sprites = new Sprite[loadedSprites.Length];

            for (var x = 0; x < loadedSprites.Length; x++)
            {
                sprites[x] = (Sprite)loadedSprites[x];
            }
            Debug.Log("Sprites are loaded -> " + sprites);
        }
    }
}
