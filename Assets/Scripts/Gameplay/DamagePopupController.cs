using Assets.Scripts.Data_Managing;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class DamagePopupController : MonoBehaviour
    {
        public static DamagePopupController Instance;

        [SerializeField] private GameObject popupPrefab;
        public ObjectPool popupPool;


        private void Start()
        {
            Instance = this;
            popupPool = GetComponent<ObjectPool>();
        }

        public void CreateDamagePopup(Vector3 position, int appliedDamage, bool isCriticalHit, bool isDamage, Color damageTextColor, int damageTextFontSize)
        {
            DamagePopup damagePopup = new DamagePopup();
            damagePopup.CreateDamagePopup(position, appliedDamage, isCriticalHit, isDamage, damageTextColor, damageTextFontSize);
        }

        public void CreateTextPopup(Vector3 position, string textPopupTextValue, Color textColor, int textFontSize)
        {
            DamagePopup damagePopup = new DamagePopup();
            damagePopup.CreateTextPopup(position, textPopupTextValue, textColor, textFontSize);
        }
    }
}