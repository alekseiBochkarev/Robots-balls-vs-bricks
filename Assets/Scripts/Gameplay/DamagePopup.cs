using UnityEngine;
using TMPro;
using Assets.Scripts.DataManaging.Utills;
using Assets.Scripts.Gameplay;

public class DamagePopup : MonoBehaviour
{

    private static int sortingOrder = 30; // is enough to display above everything
    private const float DISAPPEAR_TIMER_MAX = 0.3f;
    private const float VECTOR3_X_MAX = 0.7f;
    private const float VECTOR3_Y_MAX = 0.3f;
    private TextMeshPro textMesh;
    private float disappearTimer = DISAPPEAR_TIMER_MAX;
    private Vector3 defaultScalePopup;
    
    private float disappearSpeed = 2f;
    private Color textColor;
    private Vector3 moveVector;
    private string valueOperator;

    private void Awake() 
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        defaultScalePopup = this.transform.localScale;
    }

    private void Update() {
        UpAndDownAnimPopup();
        DisappearAndHidePopup();
    }

    // Creates a damage popup
    public void CreateDamagePopup(Vector3 position, int damageAmount, bool isCriticalHit, bool isDamage, Color damageTextColor, int textFontSize)
    {
        GameObject popupGameObject = DamagePopupController.Instance.popupPool.Instantiate(GameAssets.i.pfDamagePopup.name, position, Quaternion.identity);
        DamagePopup popupDamagePopup = popupGameObject.GetComponent<DamagePopup>();
        popupDamagePopup.Setup(damageAmount, isCriticalHit, isDamage, damageTextColor, textFontSize);
    }

    // Creates a Text popup
    public void CreateTextPopup(Vector3 position, string text, Color textColor, int textFontSize)
    {
        GameObject popupGameObject = DamagePopupController.Instance.popupPool.Instantiate(GameAssets.i.pfDamagePopup.name, position, Quaternion.identity);

        DamagePopup popupDamagePopup = popupGameObject.GetComponent<DamagePopup>();
        popupDamagePopup.Setup(text, textColor, textFontSize);
    }

    public void Setup(int damageAmount, bool isCriticalHit, bool isDamage, Color damageTextColor, int damageTextFontSize)
    {
        SetValueOperator(isDamage);
        textMesh.SetText(valueOperator + damageAmount.ToString());
        if (!isCriticalHit)
        {
            // Normal hit
            SetTextMeshFontSize(damageTextFontSize);
            SetTextMeshColor(damageTextColor);
        }
        else 
        {
            // Critical hit
            SetTextMeshFontSize(TextController.FONT_SIZE_MAX);
            SetTextMeshColor(TextController.COLOR_RED);
        }
        // Sorting order need to prevent the problem with displaying popups in right order
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
        
        moveVector = Utills.GetRandomVector(VECTOR3_X_MAX, VECTOR3_Y_MAX);
    }

    public void Setup(string text, Color textColor, int textFontSize)
    {
        
        // Set Text params
        textMesh.SetText(text);
        SetTextMeshFontSize(textFontSize);
        SetTextMeshColor(textColor);
        // Sorting order need to prevent the problem with displaying popups in right order
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
        
        moveVector = Utills.GetRandomVector(VECTOR3_X_MAX, VECTOR3_Y_MAX);
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

    private void SetTextMeshFontSize(int damageTextFontSize)
    {
        textMesh.fontSize = damageTextFontSize;
    }

    private void SetTextMeshColor(Color damageTextColor)
    {
        textMesh.color = damageTextColor;
        textColor = damageTextColor;
    }

    private void DisappearAndHidePopup()
    {
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            // Start disappearing and then hide a TextPopup
            textColor.a -= disappearSpeed * Time.deltaTime;
            SetTextMeshColor(textColor);
            if (textColor.a < 0)
            {
                this.gameObject.SetActive(false);
                this.transform.localScale = defaultScalePopup;
            }
        }
    }

    private void UpAndDownAnimPopup()
    {
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
    }
}
