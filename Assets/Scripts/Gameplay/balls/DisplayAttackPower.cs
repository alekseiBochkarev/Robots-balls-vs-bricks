using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class DisplayAttackPower : MonoBehaviour
{
    private IBall ballComponent;
    [SerializeField]
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        // Найти компонент, реализующий интерфейс IBall
        ballComponent = GetComponent<IBall>();

        if (ballComponent == null)
        {
            UnityEngine.Debug.LogError("Component implementing IBall not found on the GameObject.");
            return;
        }

        // Найти или добавить компонент TextMeshPro
        //textMeshPro = GetComponent<TextMeshPro>();
        //if (textMeshPro == null)
        //{
        //    textMeshPro = gameObject.AddComponent<TextMeshPro>();
        //}

        // Настроить внешний вид текста (опционально)
        // textMeshPro.fontSize = 36;
        textMeshPro.alignment = TextAlignmentOptions.Center;

        // Обновить текст
        UpdateText();
    }

    void UpdateText()
    {
        textMeshPro.text = $"{ballComponent.GetAttackPower}";
    }

    void Update()
    {
        // Обновлять текст каждый кадр (если необходимо)
        UpdateText();
    }
}
