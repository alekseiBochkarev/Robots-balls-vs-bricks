using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    [Header("HealthBar info")]
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private float _percentageValueOfHealth;
    public float CurrentHealth { private set; get;}
    public float MaxHealth { private set; get;}
    private float _noHealth = 0f;
    private int startSliderValue = 1;

    private void Awake() {
        Debug.Log("Awake the HealthBar");
        healthBarSlider.value = startSliderValue;
    }

    public void SaveCurrentBrickHealth() 
    {
        if (gameObject.GetComponentInParent<Brick>() != null)
        CurrentHealth = (float) gameObject.GetComponentInParent<Brick>().m_currentBrickHealth;
    }

    public void SaveMaxBrickHealth() 
    {   
        MaxHealth = gameObject.GetComponentInParent<Brick>().m_maxBrickHealth;
    }

    public void SaveCurrentHealth(float currentHealth)
    {
        CurrentHealth = currentHealth;
    }

    public void SaveMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void ShowHealth() 
    {
        _percentageValueOfHealth = SetCurrentHealthAsPercentage(CurrentHealth, MaxHealth);
        healthBarSlider.value = _percentageValueOfHealth;
        Debug.Log("Show Health percent in UI -> " + _percentageValueOfHealth);
    }

    public float SetCurrentHealthAsPercentage(float currentHealth, float maxHealth) 
    {
        if (IsHealthEnough(currentHealth))
        {
            return currentHealth / maxHealth;
        }
        else
        {
            return _noHealth;
        }
    }

    private bool IsHealthEnough(float currentHealth) 
    {
        return currentHealth > 0;
    }
}