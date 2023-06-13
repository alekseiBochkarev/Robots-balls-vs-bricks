using System;

namespace Skins.Abstract
{
    public interface IInventory
    {
        int Capacity
        {
            get; set; 
            
        }
        
        bool IsFull { get; }
        IInventoryItem GetItem(Type itemType);
        IInventoryItem[] GetAllItems();
        IInventoryItem[] GetAllItems(Type itemType);
        IInventoryItem[] GetEquippedItems();
        int GetItemAmount(Type itemType);

        bool TryToAdd(object sender, IInventoryItem item);
        void Remove(object sender, Type itemType);
        bool HasItem(Type type, out IInventoryItem item);
    }
}