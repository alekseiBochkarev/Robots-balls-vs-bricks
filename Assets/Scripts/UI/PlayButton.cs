using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject _textMeshPro;

    private void Awake()
    {
        EventManager.OnLanguageChanged += Translate;
    }

    void OnEnable()
    {
        // _textMeshPro.GetComponent<TMP_Text>().text = Translator.Translate("LEVEL ") + SceneManager.GetActiveScene().buildIndex;
        Translate();
    }

    void Translate()
    {
        _textMeshPro.GetComponent<TMP_Text>().text = Translator.Translate("DAY ") + SaveManager.LoadDayData();
    }

    private void OnDestroy()
    {
        // EventManager.UpgradeStats -= ShowBallsAmountOnHUD;
        EventManager.OnLanguageChanged -= Translate;
    }


}
