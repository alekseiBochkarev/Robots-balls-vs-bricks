using UnityEngine;

namespace Skins.Abstract
{
    public interface IInventoryItemInfo
    {
        string id { get; }
        string title { get; }
        string description { get; }
        Sprite spriteIcon { get; }
    }
}