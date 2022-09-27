using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroProgressBar : MonoBehaviour
{
    public HeroLevel heroLevel {private set; get;}
    [SerializeField] private Slider slider;
    [SerializeField] private Text heroLevelText;
    private int startSliderValue = 0;


    private void Awake() 
    {
        heroLevel = new HeroLevel();
        slider.value = startSliderValue;
        ShowHeroLevelAndExperience();
    }

    private void ShowHeroLevelAndExperience()
    {
        SetUpProgressBar();
        SetHeroLevelUI();
    }

    private void SetUpProgressBar()
    {
        float experienceAsPercentage = heroLevel.SetCurrentExperienceAsPercentage();
       // Debug.Log("experienceAsPercentage is " + experienceAsPercentage);
        slider.value = experienceAsPercentage;
    }

    private void SetHeroLevelUI()
    {
        heroLevelText.text = heroLevel.CurrentHeroLevel.ToString();
    }
}