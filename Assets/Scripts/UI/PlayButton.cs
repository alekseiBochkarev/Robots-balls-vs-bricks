using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject _textMeshPro;

    void OnEnable()
    {
       // _textMeshPro.GetComponent<TMP_Text>().text = Translator.Translate("DAY ") + SceneManager.GetActiveScene().buildIndex;
        _textMeshPro.GetComponent<TMP_Text>().text = Translator.Translate("DAY ") + SaveManager.LoadDayData();
    }
}
