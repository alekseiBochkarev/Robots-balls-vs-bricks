using UnityEngine;
using UnityEngine.UI;
public class StringToText : MonoBehaviour
{
    [SerializeField] private Text _textField;
    [SerializeField] private string text;

    private void OnEnable()
    {
        Invoke("TranslateLate", 0.005f);
    }

    private void TranslateLate()
    {
        _textField.text = Translator.Translate(text);
    }
}
