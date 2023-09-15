using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonBlocker : MonoBehaviour
{
    [SerializeField] private string _buttonName;
    [SerializeField] private Image _buttonImage;
	[SerializeField] private int _minLevelWhereAvailable;
	[SerializeField] private GameObject _lockImage;
	private GameObject camera;
	
	private void Awake() 
	{
		
		camera = GameObject.Find("MainCamera");
	}
	void OnEnable()
    {
        if (_minLevelWhereAvailable <= SceneManager.GetActiveScene().buildIndex) 
		{
			SaveSkinIsActivate(_buttonName);
		}
        if (LoadSkinSIsActivate(_buttonName) != 1)
        {
            _lockImage.SetActive(true);
            _buttonImage.color = new Color32(0, 0, 0, 100);
            GetComponent<Button>().interactable = false;
        }
        else
        {
            _lockImage.SetActive(false);
            _buttonImage.color = new Color32(255, 255, 255, 255);
            GetComponent<Button>().interactable = true;
        }
    }

	private void SaveSkinIsActivate(string name)
    {
        PlayerPrefs.SetInt(name, 1);
        PlayerPrefs.Save();
    }

    private int LoadSkinSIsActivate(string name)
    {
        int defaultSkinStateValue = 0;
        if (PlayerPrefs.HasKey(name))
        {
            return PlayerPrefs.GetInt(name);
        }
        else
        {
            return defaultSkinStateValue;
        }
    }
}
