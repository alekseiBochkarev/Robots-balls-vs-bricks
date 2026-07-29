using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITopStatsPanel : MonoBehaviour
{
    //private HeroStats heroStats;
    // Текущие уровни статов
    public int levelScene;
    public int healthLevel;
    public int attackLevel;
    public int starterBallsLevel;
    public int sightLengthLevel;
    
    // Тексты для отображения уровней/значений
    [SerializeField] private Text levelValueText;
    [SerializeField] private Text coinsValueText;
    [SerializeField] private Text healthLevelText;
    [SerializeField] private Text healthRealText;
    [SerializeField] private Text attackLevelText;
    [SerializeField] private Text attackRealText;
    [SerializeField] private Text starterBallsLevelText;
    [SerializeField] private Text starterBallRealText;
    [SerializeField] private Text sightLengthLevelText;
    [SerializeField] private Text sightLengthRealText;

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
        EventManager.SkinChanged += UpdateValuesAndPrefabs;
        EventManager.UpgradeStats += UpdateValuesAndPrefabs;
        EventManager.UpgradeAttackPowerStat += UpdateValuesAndPrefabs;
        EventManager.HeroTakesDamage += UpdateValuesAndPrefabs;
        EventManager.HeroHealsUp += UpdateValuesAndPrefabs;
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

    private void OnDestroy()
    {
        EventManager.SkinChanged -= UpdateValuesAndPrefabs;
        EventManager.UpgradeStats -= UpdateValuesAndPrefabs;
        EventManager.UpgradeAttackPowerStat -= UpdateValuesAndPrefabs;
        EventManager.HeroTakesDamage -= UpdateValuesAndPrefabs;
        EventManager.HeroHealsUp -= UpdateValuesAndPrefabs;
    }

   /* private HeroStats getHeroStats()
    {
        heroStats = new HeroStats();
        return heroStats;
    }*/

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
        //levelValueText.text = Translator.Translate("LEVEL ") + $"{SceneManager.GetActiveScene().buildIndex}";
        levelValueText.text = Translator.Translate("DAY ") + $"{SaveManager.LoadDayData()}";
        healthLevelText.text = $"{healthLevel}" + Translator.Translate(" Lev.");
        healthRealText.text = $"{Hero.CurrentHealth}" + "/" + $"{HeroStats.Health}";
        attackLevelText.text = $"{attackLevel}" + Translator.Translate(" Lev.");
        attackRealText.text = $"{HeroStats.Attack}";
        starterBallsLevelText.text = $"{starterBallsLevel}" + Translator.Translate(" Lev.");
        starterBallRealText.text = $"{HeroStats.StarterBalls}";
        sightLengthLevelText.text = $"{sightLengthLevel}" + Translator.Translate(" Lev.");
        sightLengthRealText.text = $"{HeroStats.SightLength}";
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
