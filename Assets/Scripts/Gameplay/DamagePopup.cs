using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{

    // Creates a damage popup
    public static DamagePopup CreateDamagePopup(Vector3 position, int damageAmount, bool isCriticalHit, bool isDamage) 
    {
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isCriticalHit, isDamage);

        return damagePopup;
    }

    private static int sortingOrder;
    private const float DISAPPEAR_TIMER_MAX = 0.3f;
    private const float VECTOR3_X_MAX = 0.7f;
    private const float VECTOR3_Y_MAX = 0.3f;
    private TextMeshPro textMesh;
    private float disappearTimer;
    
    private float disappearSpeed = 2f;
    private Color textColor;
    private Vector3 moveVector;
    private string valueOperator;

    private void Awake() 
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    private void SetValueOperator(bool isDamage)
    {
        if (isDamage)
        {
            valueOperator = "-";
        }
        else
        {
            valueOperator = "+";
        }
    }

    public void Setup(int damageAmount, bool isCriticalHit, bool isDamage)
    {
        SetValueOperator(isDamage);
        textMesh.SetText(valueOperator + damageAmount.ToString());
        if (!isCriticalHit)
        {
            // Normal hit
            textMesh.fontSize = 36;
            textColor = Color.yellow;
        }
        else 
        {
            textMesh.fontSize = 45;
            textColor = Color.red;
        }
        textMesh.color = textColor;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        // Sorting order need to prevent the problem with displaying popups in right order
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;

        moveVector = Utills.GetRandomVector(VECTOR3_X_MAX, VECTOR3_Y_MAX);
    }

    private void Update() {
        transform.position += moveVector * Time.deltaTime; // changes position of DamagePopup UP on z coord
        moveVector -= moveVector * 0.1f * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
        {
            // First half of the popup lifetime
            float increaseScaleAmount = 0.2f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else 
        {
            // Second half of the popup lifetime
            float decreaseScaleAmount = 0.2f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            // Start disappearing and then destroy a DamagePopup
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
