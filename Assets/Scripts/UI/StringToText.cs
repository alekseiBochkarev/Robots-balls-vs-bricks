using UnityEngine;
using TMPro;
public class StringToText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textField;
    [SerializeField] private string text;

    private void OnEnable()
    {
        _textField.text = Translator.Translate(text);
    }
}