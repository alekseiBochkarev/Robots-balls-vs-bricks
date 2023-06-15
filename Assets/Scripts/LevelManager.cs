using Assets.Scripts.Gameplay.Combo;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

 //   public GameObject m_GameMenuPanel;
    public GameObject m_TopStatsPanel;
    public GameObject m_BeforeStartPanel;
    public GameObject m_GameOverPanel;
    public GameObject m_GameWinPanel;
    public GameObject m_Scores;
    [SerializeField] private GameObject m_Hero;
    public Text m_GameOverFinalScore;

	private bool energyIsOver;
	private bool lifeIsOver;

    [SerializeField] private int s_ReturnedBallsAmount = 0;
    [SerializeField] private int playerBallsAmount;
    private SpecialAttackPanelController m_SpecialAttackPanelController;
    Collider2D[] colliders;
    private float vision = 10f;

    public enum LevelState {BEFOREPLAYABLE, PLAYABLE, GAMEOVER, WIN }
    private LevelState m_State; //= GameState.MainMenu;

    public LevelState m_LevelState
    {
        set
        {
            m_State = value;

            switch(value)
            {
                case LevelState.BEFOREPLAYABLE:
                    m_Hero.transform.position = new Vector3(0f, 1.1f);
                    m_Hero.transform.localScale = new Vector3(1f, 1f, 1f);
                    //  m_GameMenuPanel.SetActive(false);
                    m_TopStatsPanel.SetActive(false);
                    m_BeforeStartPanel.SetActive(true);
                    m_GameOverPanel.SetActive(false);
                    m_GameWinPanel.SetActive(false);
                    m_Scores.SetActive(false);

                    BallLauncher.Instance.m_CanPlay = false;
                    BallLauncher.Instance.ResetPositions();
                    break;
                case LevelState.PLAYABLE:
                    if(Saver.Instance.HasSave())
                    {

                    }
                    else
                    {
                        m_Hero.transform.position = new Vector3(0f, -4.1f);
                        m_Hero.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                        // m_GameMenuPanel.SetActive(true);
                        m_BeforeStartPanel.SetActive(false);
                        m_GameOverPanel.SetActive(false);
                        m_GameWinPanel.SetActive(false);
                        m_Scores.SetActive(true);
                        m_TopStatsPanel.SetActive(true);

                        BallLauncher.Instance.m_CanPlay = true;
                      //  Debug.Log("Level state, LevelOfFinalBrick " + ScoreManager.Instance.m_LevelOfFinalBrick);
                        ScoreManager.Instance.m_LevelOfFinalBrick = 0;  // temporary (after save and load)
                        // reset score (probably by conditions)
                        //ScoreManager.Instance.m_ScoreText.text = ScoreManager.Instance.m_LevelOfFinalBrick.ToString();
                        BrickSpawner.Instance.SpawnNewBricks();
                    }
                    break;
                case LevelState.GAMEOVER:
                 //   m_GameMenuPanel.SetActive(false);
                    m_BeforeStartPanel.SetActive(false);
                    m_GameOverPanel.SetActive(true);
                    m_GameWinPanel.SetActive(false);
                    m_TopStatsPanel.SetActive(false);
                    m_Scores.SetActive(false);

                    // m_GameOverFinalScore.text = "Final Score : " + (ScoreManager.Instance.m_LevelOfFinalBrick - 1).ToString();
                    if (energyIsOver) {
					m_GameOverFinalScore.text = "energy is over"; 
					} else 
					if (lifeIsOver) {
					m_GameOverFinalScore.text = "life is over";
					} else {
					m_GameOverFinalScore.text = "I don't know why you are over";
					}
                    BallLauncher.Instance.m_CanPlay = false;
                    BallLauncher.Instance.ResetPositions();
					EventManager.OnGameLose();
                    break;
                case LevelState.WIN:
                 //   m_GameMenuPanel.SetActive(false);
                    m_BeforeStartPanel.SetActive(false);
                    m_GameOverPanel.SetActive(false);
                    m_GameWinPanel.SetActive(true);
                    m_TopStatsPanel.SetActive(false);
                    m_Scores.SetActive(false);

                    m_GameOverFinalScore.text = "You win";
                    BallLauncher.Instance.m_CanPlay = false;
                    BallLauncher.Instance.ResetPositions();
                    EventManager.OnGameWon();
                    break;

            }
        }
        get
        {
            return m_State;
        }
    }
    
    private void Awake()
    {
        Instance = this;
        m_Hero = GameObject.FindGameObjectWithTag("Hero");
        EventManager.BallsReturned += CheckBallsAndOpenSpecAttackPanelAndContinuePlaying;
        EventManager.ResetReturningBallsAmount += ResetReturningBallsAmount;
		EventManager.EnergyIsOverEvent += ShowLosePanelBecauseEnergyIsOver;
		EventManager.LifeIsOverEvent += ShowLosePanelBecauseLifeIsOver;
        m_SpecialAttackPanelController = GameObject.Find("SpecialAttackUI").GetComponent<SpecialAttackPanelController>();
        m_TopStatsPanel = GameObject.FindGameObjectWithTag("TopStatsPanel");
    }

    private void Start()
    {
        m_LevelState = LevelState.BEFOREPLAYABLE;
       // Debug.Log("start gameManager LevelState " + m_LevelState);
      //  Debug.Log("instanse state " + Instance.m_LevelState);
    }

    //? maybe we can delete this
    //private void Update()
    //{
    //    ScoreManager.Instance.m_ScoreText.text = ScoreManager.Instance.m_LevelOfFinalBrick.ToString();
    //    playerBallsAmount = Balls.Instance.PlayerBallsAmount;
    //}

	private void ShowLosePanelBecauseEnergyIsOver () {
		energyIsOver = true;
		m_LevelState = LevelState.GAMEOVER;
	}

	private void ShowLosePanelBecauseLifeIsOver () {
		lifeIsOver = true;
		m_LevelState = LevelState.GAMEOVER;
	}

    private void CheckBallsAndOpenSpecAttackPanelAndContinuePlaying () {
       // Debug.Log("CheckBallsAndOpenSpecAttackPanelAndContinuePlaying");
        s_ReturnedBallsAmount ++;
        if (s_ReturnedBallsAmount >= Balls.Instance.PlayerBallsAmount)  
        StartCoroutine(OpenSpecAttackPanelAndContinuePlaying());
    }

    IEnumerator OpenSpecAttackPanelAndContinuePlaying()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, vision);
        for (int i = 0; i < colliders.Length; i ++) {
            if (colliders[i].gameObject.GetComponent<IBall>() != null) {
                colliders[i].gameObject.GetComponent<IBall>().DestroyBall();
            }
        }
        Debug.Log("OpenSpecAttackPanelAndContinuePlaying");
        if (m_LevelState == LevelState.PLAYABLE)
        {
            int magicBallCount = m_SpecialAttackPanelController.GetMagicBallAmount();
            //Debug.Log("magicBallCount = " + magicBallCount);
            for (int i = 0; i < magicBallCount; i++)
            {
                Debug.Log("try to execute ShowSpecAttackPanelAndClose");
                yield return StartCoroutine(ShowSpecAttackPanelAndClose());
            }
        }
        Debug.Log("invoke continuePlaying");
        StartCoroutine(BallLauncher.Instance.ContinuePlaying());
        //m_SpriteRenderer.enabled = false;
    }
    
    IEnumerator ShowSpecAttackPanelAndClose()
    {
        while (ComboLauncher.Instance.CanPlay == false)
        {
            yield return new WaitForSeconds(1f);
        }
        m_SpecialAttackPanelController.ShowSpecAttackPanel();
        while (m_SpecialAttackPanelController.IsSpecAttackPanelOpened == true)
        {
            yield return null;
        }
        m_SpecialAttackPanelController.MinusMagicBallAmount();
    }

    public void ResetReturningBallsAmount()
    {
        //Debug.Log("ResetReturningBallsAmount");
        s_ReturnedBallsAmount = 0;
    }

    private void OnDestroy()
    {
        EventManager.BallsReturned -= CheckBallsAndOpenSpecAttackPanelAndContinuePlaying;
        EventManager.ResetReturningBallsAmount -= ResetReturningBallsAmount;
		EventManager.EnergyIsOverEvent -= ShowLosePanelBecauseEnergyIsOver;
		EventManager.LifeIsOverEvent -= ShowLosePanelBecauseLifeIsOver;
    }
}