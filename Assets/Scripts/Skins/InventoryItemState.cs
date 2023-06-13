using System;
using Skins.Abstract;

namespace Skins
{
    [Serializable]
    public class InventoryItemState : IInventoryItemState
    {
        public bool isEquipped;
        public bool IsEquipped { get => isEquipped; set => isEquipped = value; }

        public InventoryItemState()
        {
            isEquipped = false;
        }
    }
}