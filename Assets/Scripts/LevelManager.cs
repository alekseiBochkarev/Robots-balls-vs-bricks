using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject m_GameMenuPanel;
    public GameObject m_GameOverPanel;
    public GameObject m_Scores;
    public Text m_GameOverFinalScore;

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
                        Debug.Log("Level state, LevelOfFinalBrick " + ScoreManager.Instance.m_LevelOfFinalBrick);
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
    }

    private void Start()
    {
        m_LevelState = LevelState.PLAYABLE;
        Debug.Log("start gameManager LevelState " + m_LevelState);
        Debug.Log("instanse state " + Instance.m_LevelState);
    }

    //? maybe we can delete this
    private void Update()
    {
        ScoreManager.Instance.m_ScoreText.text = ScoreManager.Instance.m_LevelOfFinalBrick.ToString();
    }
}