using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UITopStatsPanel : MonoBehaviour
{
    // Текущие уровни статов
    public int levelScene;
    public int healthLevel;
    public int attackLevel;
    public int starterBallsLevel;
    public int sightLengthLevel;

    // Тексты для отображения уровней/значений
    [SerializeField] private TextMeshProUGUI levelValueText;
    [SerializeField] private TextMeshProUGUI coinsValueText;
    [SerializeField] private TextMeshProUGUI healthLevelText;
    [SerializeField] private TextMeshProUGUI attackLevelText;
    [SerializeField] private TextMeshProUGUI starterBallsLevelText;
    [SerializeField] private TextMeshProUGUI sightLengthLevelText;

    // Префабы статов
    [SerializeField] private Transform healthStatPrefab;
    [SerializeField] private Transform attackStatPrefab;
    [SerializeField] private Transform starterBallsStatPrefab;
    [SerializeField] private Transform sightLengthStatPrefab;

    // Контроллеры Префабов
    private HealthPrefabController healthPrefabController;
    private AttackPrefabController attackPrefabController;
    private StarterBallsPrefabController starterBallsPrefabController;
    private SightLengthPrefabController sightLengthPrefabController;

    private void Awake()
    {
        // Подгружаем контроллеры префабов
        healthPrefabController = healthStatPrefab.GetComponent<HealthPrefabController>();
        attackPrefabController = attackStatPrefab.GetComponent<AttackPrefabController>();
        starterBallsPrefabController = starterBallsStatPrefab.GetComponent<StarterBallsPrefabController>();
        sightLengthPrefabController = sightLengthStatPrefab.GetComponent<SightLengthPrefabController>();
        if (healthPrefabController == null || attackPrefabController == null || starterBallsPrefabController == null || sightLengthPrefabController == null)
            return;
        UpdateValuesAndPrefabs();
        ShowLevelValues();
    }

    private void OnEnable()
    {
        // Проверяем, что контроллеры не null, иначе можно поймать ошибку,
        // когда мы пытаемся получить значения префабов
        if (healthPrefabController == null || attackPrefabController == null || starterBallsPrefabController == null || sightLengthPrefabController == null)
            return;
        UpdateValuesAndPrefabs();
        ShowLevelValues();
    }
    
    public void ShowLevelValues()
    {
        levelValueText.text = Translator.Translate("LEVEL ") + $"{SceneManager.GetActiveScene().buildIndex}"; ;
        healthLevelText.text = $"{healthLevel}";
        attackLevelText.text = $"{attackLevel}";
        starterBallsLevelText.text = $"{starterBallsLevel}";
        sightLengthLevelText.text = $"{sightLengthLevel}";
    }

    public void UpdateValuesAndPrefabs()
    {
        // Возможно переделать все контроллеры под абстрактный?, чтобы интерфейс у них был общий, наверное
        healthPrefabController.LoadHealthLevelAndShowSprite();
        attackPrefabController.LoadAttackLevelAndShowSprite();
        starterBallsPrefabController.LoadStarterBallsLevelAndShowSprite();
        sightLengthPrefabController.LoadSightLengthLevelAndShowSprite();

        LoadLevelValues();
    }

    private void LoadLevelValues()
    {
        // Подгружаем значения текущих уровней для статов
        // levelScene = ???
        healthLevel = healthPrefabController.CurrentHealthLevel;
        attackLevel = attackPrefabController.CurrentAttackLevel;
        starterBallsLevel = starterBallsPrefabController.CurrentBallsLevel;
        sightLengthLevel = sightLengthPrefabController.CurrentSightLengthLevel;
    }
}
