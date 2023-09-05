using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UITopStatsPanel : MonoBehaviour
{
    private HeroStats heroStats;
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
    [SerializeField] private TextMeshProUGUI healthRealText;
    [SerializeField] private TextMeshProUGUI attackLevelText;
    [SerializeField] private TextMeshProUGUI attackRealText;
    [SerializeField] private TextMeshProUGUI starterBallsLevelText;
    [SerializeField] private TextMeshProUGUI starterBallRealText;
    [SerializeField] private TextMeshProUGUI sightLengthLevelText;
    [SerializeField] private TextMeshProUGUI sightLengthRealText;

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

    private void Start()
    {
        // Подгружаем контроллеры префабов
        // healthPrefabController = healthStatPrefab.GetComponent<HealthPrefabController>();
        // attackPrefabController = attackStatPrefab.GetComponent<AttackPrefabController>();
        // starterBallsPrefabController = starterBallsStatPrefab.GetComponent<StarterBallsPrefabController>();
        // sightLengthPrefabController = sightLengthStatPrefab.GetComponent<SightLengthPrefabController>();
        //   if (healthPrefabController == null || attackPrefabController == null || starterBallsPrefabController == null || sightLengthPrefabController == null)
        //      return;
        UpdateValuesAndPrefabs();
        //ShowLevelValues();
    }

    private HeroStats getHeroStats()
    {
        heroStats = new HeroStats();
        return heroStats;
    }

    private void OnEnable()
    {
        // Проверяем, что контроллеры не null, иначе можно поймать ошибку,
        // когда мы пытаемся получить значения префабов
      //  if (healthPrefabController == null || attackPrefabController == null || starterBallsPrefabController == null || sightLengthPrefabController == null)
      //      return;
        UpdateValuesAndPrefabs();
        //ShowLevelValues();
    }
    
    public void ShowLevelValues()
    {
        levelValueText.text = Translator.Translate("LEVEL ") + $"{SceneManager.GetActiveScene().buildIndex}";
        healthLevelText.text = $"{healthLevel}" + "L";
        healthRealText.text = $"{getHeroStats().Health}";
        attackLevelText.text = $"{attackLevel}" + "L";
        attackRealText.text = $"{getHeroStats().Attack}";
        starterBallsLevelText.text = $"{starterBallsLevel}" + "L";
        starterBallRealText.text = $"{getHeroStats().StarterBalls}";
        sightLengthLevelText.text = $"{sightLengthLevel}" + "L";
        sightLengthRealText.text = $"{getHeroStats().SightLength}";
    }

    public void UpdateValuesAndPrefabs()
    {
        // Возможно переделать все контроллеры под абстрактный?, чтобы интерфейс у них был общий, наверное
        healthStatPrefab.GetComponent<HealthPrefabController>()
            .Init();
        healthStatPrefab.GetComponent<HealthPrefabController>().LoadHealthLevelAndShowSprite();
        attackStatPrefab.GetComponent<AttackPrefabController>()
            .Init();
        attackStatPrefab.GetComponent<AttackPrefabController>().LoadAttackLevelAndShowSprite();
        starterBallsStatPrefab.GetComponent<StarterBallsPrefabController>()
            .Init();
        starterBallsStatPrefab.GetComponent<StarterBallsPrefabController>().LoadStarterBallsLevelAndShowSprite();
        sightLengthStatPrefab.GetComponent<SightLengthPrefabController>()
            .Init();
        sightLengthStatPrefab.GetComponent<SightLengthPrefabController>().LoadSightLengthLevelAndShowSprite();
        
        LoadLevelValues();
        ShowLevelValues();
    }

    private void LoadLevelValues()
    {
        // Подгружаем значения текущих уровней для статов
        // levelScene = ???
        healthLevel = healthStatPrefab.GetComponent<HealthPrefabController>().CurrentHealthLevel;
        attackLevel = attackStatPrefab.GetComponent<AttackPrefabController>().CurrentAttackLevel;
        starterBallsLevel = starterBallsStatPrefab.GetComponent<StarterBallsPrefabController>().CurrentBallsLevel;
        sightLengthLevel = sightLengthStatPrefab.GetComponent<SightLengthPrefabController>().CurrentSightLengthLevel;
    }
}
