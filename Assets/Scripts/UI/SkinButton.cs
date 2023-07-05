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
	[SerializeField] private int _minLevelWhereAvailable;
	[SerializeField] private GameObject _lockImage;
	[SerializeField] private bool isFree;
	[SerializeField] private GameObject _buyButton;
    private GameObject[] _heroSkins;
    private GameObject _skinMenuHeroImage;
	private string secretKeyWord = "asdfadsfoypmutr";
    
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
				_textMeshPro.GetComponent<TMP_Text>().text = "win " + (_minLevelWhereAvailable - 1) + " level";
        	} else 
			{
				_lockImage.SetActive(false);
				_buttonImage.color = new Color32(255,255,225,100);
				GetComponent<Button>().interactable = true;
			}
		} else 
		{
			_buyButton.SetActive(true);
		}
    }

    public void changeCurrentSkin()
    {
        foreach (var _heroSkin in _heroSkins)
        {
            _heroSkin.GetComponent<HeroBody>().SetSkin(_robotName);
        }

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

}
