using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public Image healthBarImage;
    [SerializeField] public float CurrentHealth { set; get;}
    [SerializeField] public float MaxHealth { set; get;}
    [SerializeField] private float _percentageValueOfHealth;
    public float _fillParameter;
    private float _fullHealth = 1f;
    private float _noHealth = 0f;
    private int _maxHealth = 100;


    private void Awake() {
        _fillParameter = _fullHealth;
     //   ShowHealth(_fullHealth);
        Debug.Log("Awake the HealthBar");
    }

    public void SaveMaxBrickHealth() 
    {
        MaxHealth = (float) gameObject.GetComponentInParent<Brick>().m_maxBrickHealth;
        gameObject.GetComponentInChildren<Image>().fillAmount = 0f;
        Debug.Log("MaxHealth with game object is -> " + MaxHealth);
    }
    public void SaveCurrentBrickHealth() 
    {
        CurrentHealth = (float) gameObject.GetComponentInParent<Brick>().m_currentBrickHealth;
        Debug.Log("CurrentHealth with game object is -> " + CurrentHealth);
    }
    
    public void ShowHealth(float healthPercentage) 
    {
        Debug.Log("Show Health percent in UI -> " + healthPercentage);
        if (!IsHealthEnough()) 
        {
            healthPercentage = 0f;
            Debug.Log ("Show health is not enough");
        }
        healthBarImage.fillAmount = healthPercentage;
    }

    public void ShowHealthWithPercentage() 
    {
        _percentageValueOfHealth = SetCurrentHealthAsPercentage(CurrentHealth, MaxHealth);
         Debug.Log("Show Health percent in UI BEFORE SHOWING -> " + _percentageValueOfHealth);
        healthBarImage.fillAmount = _percentageValueOfHealth;
        Debug.Log("Show Health percent in UI -> " + _percentageValueOfHealth);
    }

    private float SetCurrentHealthAsPercentage(float currentHealth, float maxHealth) 
    {
        
        Debug.Log("_currentHealth BEFORE DIVIDING -> " + currentHealth);
        Debug.Log("_maxHealth is -> BEFORE DIVIDING ->" + maxHealth);
        if (currentHealth <= 0 || maxHealth <= 0 )
        {
        Debug.Log("Percentage of health is -> 0");
            return 0f;
        }
        else
        {
        float percentage = currentHealth / maxHealth;
        Debug.Log("Percentage of health is -> " + percentage);
        return percentage;
        }
    }

    private bool IsHealthEnough() 
    {
        return CurrentHealth <=0;
    }
}
