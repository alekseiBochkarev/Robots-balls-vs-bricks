using System;
using Skins.Abstract;

namespace Skins.Heads
{
    public class RobotHead : IInventoryItem
    {
        public IInventoryItemInfo info { get; }
        public IInventoryItemState state { get; }
        public Type Type => GetType();

        public RobotHead(IInventoryItemInfo info)
        {
            this.info = info;
            state = new InventoryItemState();
        }
        
    }
}