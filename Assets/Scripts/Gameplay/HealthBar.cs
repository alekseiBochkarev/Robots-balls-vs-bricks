using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    [Header("HealthBar info")]
    [SerializeField] public Image healthBarImage;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private float _percentageValueOfHealth;
    public float CurrentHealth { private set; get;}
    public float MaxHealth { private set; get;}
    private float _noHealth = 0f;

    private void Awake() {
        Debug.Log("Awake the HealthBar");
    }

    public void SaveCurrentBrickHealth() 
    {
        CurrentHealth = (float) gameObject.GetComponentInParent<Brick>().m_currentBrickHealth;
    }

    public void SaveMaxBrickHealth() 
    {   
        MaxHealth = (float) gameObject.GetComponentInParent<Brick>().m_maxBrickHealth;
    }

    public void ShowHealth() 
    {
        _percentageValueOfHealth = SetCurrentHealthAsPercentage(CurrentHealth, MaxHealth);
        healthBarImage.fillAmount = _percentageValueOfHealth;
        healthBarImage.color = _gradient.Evaluate(_percentageValueOfHealth);
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