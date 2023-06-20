using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunItem : MonoBehaviour
{
    public string nameItem;
    public string priceItem;
    public ShopGun scriptShopGun;

    public TMP_Text TextItem;
    public bool isBuy;

    public void Start()
    {
        if (!isBuy)
        {
            TextItem.text = priceItem;
        }
        else
        {
            TextItem.text = "Куплено";
        }
    }

    public void BuyItem()
    {
        if (!isBuy)
        {
            scriptShopGun.nameItem = nameItem;
            scriptShopGun.priceItem = priceItem;

            scriptShopGun.BuyItem();
            isBuy = true;
        }
    }
}
