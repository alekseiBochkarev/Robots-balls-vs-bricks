using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinButton : MonoBehaviour
{
    [SerializeField] private string _robotName;
    [SerializeField] private Image _buttonImage;
	[SerializeField] private GameObject _textMeshPro;
	[SerializeField] private int _minLevelWhereAvailable;
	[SerializeField] private GameObject _lockImage;
    private GameObject[] _heroSkins;
    private GameObject _skinMenuHeroImage;
    void OnEnable()
    {
		_buttonImage.sprite = Resources.Load<Sprite>("Robots/" + _robotName);
		_textMeshPro.GetComponent<TMP_Text>().text = _robotName;
        _heroSkins = GameObject.FindGameObjectsWithTag("HeroSkin");
        _skinMenuHeroImage = GameObject.FindWithTag("SkinMenuHeroImage");
		//lock button if not available
		if (_minLevelWhereAvailable >= SaveManager.LoadSceneData()) 
		{
			_lockImage.SetActive(true);
			_buttonImage.color = new Color32(0,0,0,100);
			GetComponent<Button>().interactable = false;
        } else 
		{
			_lockImage.SetActive(false);
			_buttonImage.color = new Color32(255,255,225,100);
			GetComponent<Button>().interactable = true;
		}
    }

    public void changeCurrentSkin()
    {
        foreach (var _heroSkin in _heroSkins)
        {
            _heroSkin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Robots/" + _robotName);
        }

        _skinMenuHeroImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Robots/" + _robotName);
    }
}
