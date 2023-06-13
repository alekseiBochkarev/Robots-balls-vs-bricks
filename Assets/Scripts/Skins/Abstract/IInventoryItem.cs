using System;

namespace Skins.Abstract
{
    public interface IInventoryItem
    {
        IInventoryItemInfo info { get; }
        IInventoryItemState state { get; }
        Type Type { get; }

    }
}