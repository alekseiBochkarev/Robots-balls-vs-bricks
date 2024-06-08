using UnityEngine;
using TMPro;
public class StringToText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textField;
    [SerializeField] private string text;

    private void OnEnable()
    {
        Invoke("TranslateLate", 0.05f);
    }

    private void TranslateLate()
    {
        _textField.text = Translator.Translate(text);
    }
}