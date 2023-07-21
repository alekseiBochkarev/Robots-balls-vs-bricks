using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SkinButton : MonoBehaviour
{
    [SerializeField] private string _robotName;
    [SerializeField] private Image _buttonImage;
	[SerializeField] private GameObject _textMeshPro;
	[SerializeField] private GameObject _tmpCostOnBuyButton;
	[SerializeField] private int _minLevelWhereAvailable;
	[SerializeField] private GameObject _lockImage;
	[SerializeField] private bool isFree;
	[SerializeField] private int _skinCost;
	[SerializeField] private GameObject _buyButton;
	[SerializeField] private AudioClip clip;
	[SerializeField] private AudioClip successClip;
	private GameObject camera;
	private Coins coins;
    private GameObject[] _heroSkins;
    private GameObject _skinMenuHeroImage;
	private string secretKeyWord = "asdfadsfoypmutr";
    
	
	private void Awake() 
	{
		coins = new Coins();
		camera = GameObject.Find("MainCamera");
	}
	void OnEnable()
    {
		if (_minLevelWhereAvailable <= SceneManager.GetActiveScene().buildIndex) 
		{
			SaveSkinIsActivate(_robotName);
		}
		_buttonImage.sprite = Resources.Load<Sprite>("Robots/" + _robotName);
		_textMeshPro.GetComponent<TMP_Text>().text = _robotName;
        _heroSkins = GameObject.FindGameObjectsWithTag("HeroSkin");
        _skinMenuHeroImage = GameObject.FindWithTag("SkinMenuHeroImage");
		if (isFree) {
			//lock button if not available
			if (LoadSkinSIsActivate(_robotName) != 1) 
			{
				_lockImage.SetActive(true);
				_buttonImage.color = new Color32(0,0,0,100);
				GetComponent<Button>().interactable = false;
				_textMeshPro.GetComponent<TMP_Text>().text = Translator.Translate("win ") + (_minLevelWhereAvailable - 1) + Translator.Translate(" level");
        	} else 
			{
				_lockImage.SetActive(false);
				_buttonImage.color = new Color32(255,255,255,255);
				GetComponent<Button>().interactable = true;
			}
		} else if (LoadSkinSIsBought(_robotName) != 1)
		{
			_buyButton.SetActive(true);
			_tmpCostOnBuyButton.GetComponent<TMP_Text>().text = _skinCost.ToString(); //+ Translator.Translate(" buy");
		} else 
		{
			_buyButton.SetActive(false);
		}
    }

    public void changeCurrentSkin()
    {
        foreach (var _heroSkin in _heroSkins)
        {
            _heroSkin.GetComponent<HeroBody>().SetSkin(_robotName);
        }
        camera.GetComponent<AudioManager>().PlayAudio(clip); 
        _skinMenuHeroImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Robots/" + _robotName);
    }

	private void SaveSkinIsActivate(string skin)
    {
        PlayerPrefs.SetInt(skin, 1);
        PlayerPrefs.Save();
    }

    private int LoadSkinSIsActivate(string skin)
    {
        int defaultSkinStateValue = 0;
        if (PlayerPrefs.HasKey(skin))
        {
            return PlayerPrefs.GetInt(skin);
        }
        else
        {
            return defaultSkinStateValue;
        }
    }

	private void SaveSkinIsBought(string skin)
    {
        PlayerPrefs.SetInt(skin + "Bought", 1);
        PlayerPrefs.Save();
    }

	private int LoadSkinSIsBought(string skin)
    {
        int defaultSkinIsBought = 0;
        if (PlayerPrefs.HasKey(skin + "Bought"))
        {
            return PlayerPrefs.GetInt(skin + "Bought");
        }
        else
        {
            return defaultSkinIsBought;
        }
    }

	public void BuySkin() 
	{
		if(coins.LoadCoins() >= _skinCost) 
		{
			coins.RemoveCoins(_skinCost);
			camera.GetComponent<AudioManager>().PlayAudio(successClip); 
			WalletController.Instance.ShowCoins();
			SaveSkinIsBought(_robotName);
			_buyButton.SetActive(false);
		}
	}

}
