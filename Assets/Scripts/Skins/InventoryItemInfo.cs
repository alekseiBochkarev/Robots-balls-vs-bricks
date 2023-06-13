using Skins.Abstract;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Skins
{
    [CreateAssetMenu(fileName = "InventoryItemInfo", menuName = "Gameplay/Items/Create New ItemInfo")]
    public class InventoryItemInfo : ScriptableObject, IInventoryItemInfo
    {
        [SerializeField] private string _id;
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _spriteIcon;

        public string id => _id;
        public string title => _title;
        public string description => _description;
        public Sprite spriteIcon => _spriteIcon;
    }
}