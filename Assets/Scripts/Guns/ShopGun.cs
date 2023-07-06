using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class ShopGun : MonoBehaviour
{
    [HideInInspector]
    public string nameItem;
    [HideInInspector]
    public string priceItem;
    private ShopGun.DataPlayer _dataPlayer = new ShopGun.DataPlayer();
    public GameObject[] allItem;

    private void Awake()
    {
        allItem = GameObject.FindGameObjectsWithTag("GunItemInShop");
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("SaveGame"))
        {
            LoadGame();
        }
        else
        {
            SaveGame();
            LoadGame();
        }
    }
    public class DataPlayer
    {
      //  public int money;
      public List<string> buyItem = new List<string>();
    }

    private void SaveGame()
    {
      //  dataPlayer.money = 500;
        PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(_dataPlayer));
    }

    private void LoadGame()
    {
        _dataPlayer = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("SaveGame"));
        for (int i = 0; i < _dataPlayer.buyItem.Count; i++)
        {
            for (int y = 0; y < allItem.Length; y++)
            {
                if (allItem[y].GetComponent<GunItem>().nameItem == _dataPlayer.buyItem[i])
                {
                    allItem[y].GetComponent<GunItem>().TextItem.text = "Куплено";
                    allItem[y].GetComponent<GunItem>().isBuy = true;
                }
            }
        }
    }

    public void BuyItem()
    {
        _dataPlayer.buyItem.Add(nameItem);
        SaveGame();
        LoadGame();
    }
}
*/