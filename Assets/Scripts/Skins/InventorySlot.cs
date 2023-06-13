using System;
using Skins.Abstract;
using UnityEditor;

namespace Skins
{
    public class InventorySlot : IInventorySlot
    {
        public bool IsFull => Amount == Capacity;
        public bool IsEmpty => Item == null;
        public IInventoryItem Item { get; private set; }
        public Type ItemType => Item.Type;
        public int Amount => IsEmpty ? 0 : 1;  //может быть или 1 или 0
        public int Capacity => 1; //вместительность всегда 1
        public void SetItem(IInventoryItem item)
        {
            if(!IsEmpty)
                return;
            this.Item = item;
        }

        public void Clear()
        {
            if (IsEmpty)
                return;
            Item = null;
        }
    }
}