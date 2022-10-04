using Assets.Scripts.Gameplay.Combo;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject m_GameMenuPanel;
    public GameObject m_GameOverPanel;
    public GameObject m_Scores;
    public Text m_GameOverFinalScore;

    private static int s_ReturnedBallsAmount = 0;
    private SpecialAttackPanelController m_SpecialAttackPanelController;
    Collider2D[] colliders;
    private float vision = 10f;

    public enum LevelState { PLAYABLE, GAMEOVER, WIN }
    private LevelState m_State; //= GameState.MainMenu;

    public LevelState m_LevelState
    {
        set
        {
            m_State = value;

            switch(value)
            {
                case LevelState.PLAYABLE:
                    if(Saver.Instance.HasSave())
                    {

                    }
                    else
                    {
                        m_GameMenuPanel.SetActive(true);
                        m_GameOverPanel.SetActive(false);
                        m_Scores.SetActive(true);
                    
                        BallLauncher.Instance.m_CanPlay = true;
                      //  Debug.Log("Level state, LevelOfFinalBrick " + ScoreManager.Instance.m_LevelOfFinalBrick);
                        ScoreManager.Instance.m_LevelOfFinalBrick = 0;  // temporary (after save and load)
                        // reset score (probably by conditions)
                        //ScoreManager.Instance.m_ScoreText.text = ScoreManager.Instance.m_LevelOfFinalBrick.ToString();
                        BrickSpawner.Instance.SpawnNewBricks();
                    }
                    break;
                case LevelState.GAMEOVER:
                    m_GameMenuPanel.SetActive(false);
                    m_GameOverPanel.SetActive(true);
                    m_Scores.SetActive(false);

                    m_GameOverFinalScore.text = "Final Score : " + (ScoreManager.Instance.m_LevelOfFinalBrick - 1).ToString();
                    BallLauncher.Instance.m_CanPlay = false;
                    BallLauncher.Instance.ResetPositions();
                    break;
                case LevelState.WIN:
                    m_GameMenuPanel.SetActive(false);
                    m_GameOverPanel.SetActive(true);
                    m_Scores.SetActive(false);

                    m_GameOverFinalScore.text = "You win";
                    BallLauncher.Instance.m_CanPlay = false;
                    BallLauncher.Instance.ResetPositions();
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
        EventManager.BallsReturned += CheckBallsAndOpenSpecAttackPanelAndContinuePlaying;
        EventManager.ResetReturningBallsAmount += ResetReturningBallsAmount;
        m_SpecialAttackPanelController = GameObject.Find("SpecialAttackUI").GetComponent<SpecialAttackPanelController>();
    }

    private void Start()
    {
        m_LevelState = LevelState.PLAYABLE;
       // Debug.Log("start gameManager LevelState " + m_LevelState);
      //  Debug.Log("instanse state " + Instance.m_LevelState);
    }

    //? maybe we can delete this
    private void Update()
    {
        ScoreManager.Instance.m_ScoreText.text = ScoreManager.Instance.m_LevelOfFinalBrick.ToString();
    }

    private void CheckBallsAndOpenSpecAttackPanelAndContinuePlaying () {
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
        if (LevelManager.Instance.m_LevelState == LevelManager.LevelState.PLAYABLE)
        {
            int magicBallCount = m_SpecialAttackPanelController.GetMagicBallAmount();
            for (int i = 0; i < magicBallCount; i++)
            {
                yield return StartCoroutine(ShowSpecAttackPanelAndClose());
            }
        }
        BallLauncher.Instance.ContinuePlaying();
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

    public static void ResetReturningBallsAmount()
    {
        s_ReturnedBallsAmount = 0;
    }
}