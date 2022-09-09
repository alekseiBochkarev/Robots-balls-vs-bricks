using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelName;
    [SerializeField] private TextMeshProUGUI levelDescription;
    [SerializeField] private Image levelImage;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject lockIcon;
    public void DisplayMap(LevelSO _level)
    {
        levelName.text = _level.levelName;
        levelName.color = _level.nameColor;
        levelDescription.text = _level.levelDescription;
        levelImage.sprite = _level.levelImage;

        bool mapUnclocked = PlayerPrefs.GetInt("currentScene", 0) >= _level.levelIndex;
        lockIcon.SetActive(!mapUnclocked);
        playButton.interactable = mapUnclocked;

        if (mapUnclocked)
            levelImage.color = Color.white;
        else
            levelImage.color = Color.gray;

        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(() => SceneManager.LoadScene(_level.sceneToLoad.name));
    }
}
