using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{
    private Image _buttonImage;
    private GameObject[] _heroSkins;
    private GameObject _skinMenuHeroImage;
    void OnEnable()
    {
        _heroSkins = GameObject.FindGameObjectsWithTag("HeroSkin");
        _skinMenuHeroImage = GameObject.FindWithTag("SkinMenuHeroImage");
        _buttonImage = GetComponent<Image>();
    }

    public void changeCurrentSkin()
    {
        foreach (var _heroSkin in _heroSkins)
        {
            _heroSkin.GetComponent<SpriteRenderer>().sprite = _buttonImage.sprite;
        }

        _skinMenuHeroImage.GetComponent<Image>().sprite = _buttonImage.sprite;
    }
}
