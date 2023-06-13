using System;
using System.Collections.Generic;
using System.Linq;
using Skins.Abstract;
using UnityEngine;

namespace Skins
{
    public class InventoryHead : IInventory
    {
        public event Action<object, IInventoryItem> OnInventoryItemAddedEvent;
        public event Action<object, Type> OnInventoryItemRemovedEvent;

        public int Capacity { get; set; }
        public bool IsFull => _slots.All(slot => slot.IsFull);

        private List<IInventorySlot> _slots;

        public InventoryHead(int capacity)
        {
            this.Capacity = capacity;
            _slots = new List<IInventorySlot>(capacity);
            foreach (var slot in _slots)
            {
                _slots.Add(new InventorySlot());
            }
        }
        
        public IInventoryItem GetItem(Type itemType)
        {
            return _slots.Find(slot => slot.ItemType == itemType).Item;
        }

        public IInventoryItem[] GetAllItems()
        {
            var allItems = new List<IInventoryItem>();
            foreach (var slot in _slots) 
            {
                if (!slot.IsEmpty)
                    allItems.Add(slot.Item);
            }

            return allItems.ToArray();
        }

        public IInventoryItem[] GetAllItems(Type itemType)
        {
            var allItemsOfType = new List<IInventoryItem>();
            var slotsOfType = _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType);
            foreach (var slot in slotsOfType)
            {
                allItemsOfType.Add(slot.Item);
            }
            return allItemsOfType.ToArray();
        }

        public IInventoryItem[] GetEquippedItems()
        {
            var requiredSlots = _slots.FindAll(slot => !slot.IsEmpty && slot.Item.state.IsEquipped);
            var equippedItems = new List<IInventoryItem>();
            foreach (var slot in requiredSlots)
            {
                equippedItems.Add(slot.Item);
            }

            return equippedItems.ToArray();
        }

        public int GetItemAmount(Type itemType)
        {
            var amount = 0;
            var allItemSlots = _slots
                .FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType);
            foreach (var slot in allItemSlots)
            {
                amount += slot.Amount;
            }

            return amount;
        }
        //возможно нужно будет переопределить!!!
        public bool TryToAdd(object sender, IInventoryItem item)
        {
            var emptySlot = _slots.Find(slot => slot.IsEmpty);
            if (emptySlot != null)
                return AddToSlot(sender, emptySlot, item);
            Debug.Log($"Cannot add item ({item.Type}), because there is no place");
            return false;
        }

        private bool AddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
        {
            if (slot.IsEmpty)
            {
                slot.SetItem(item);
                OnInventoryItemAddedEvent?.Invoke(sender, item);
                return true;
            }

            return false;
        }
        //вообще у нас не должно быть такой ситуации что у нас есть 2 слота с одинаковыми item
        public void Remove(object sender, Type itemType)
        {
            var slotsWithItem = GetAllSlots(itemType);
            if (slotsWithItem.Length == 0)
                return;
            var count = slotsWithItem.Length;
            for (int i = count - 1; i >= 0; i--)
            {
                var slot = slotsWithItem[i];
                slot.Clear();
                OnInventoryItemRemovedEvent?.Invoke(sender, itemType);
                break;
            }
        }

        public bool HasItem(Type type, out IInventoryItem item)
        {
            item = GetItem(type);
            return item != null;
        }

        public IInventorySlot[] GetAllSlots(Type itemType)
        {
            return _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType).ToArray();
        }

        public IInventorySlot[] GetAllSlots()
        {
            return _slots.ToArray();
        }
    }
}