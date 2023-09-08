using System.Collections.Generic;
using CodeMonkey;
using Interfaces;
using UnityEngine;

public class Balls : MonoBehaviour, IResetToDefaultValues
{
    public static Balls Instance;

    //public HeroStats _heroStats;
    public static Dictionary<int, GameObject> ballsInScene;
    private AbstractBall m_BallPrefab;
    public List<AbstractBall> PlayerBalls { private set; get; }
    [SerializeField] private int startBallsAmount;
    [SerializeField] private int StarterRocketBall;
    [SerializeField] private int StarterIceBall;
    [SerializeField] private int StarterLaserHorizontalBall;
    [SerializeField] private int StarterLaserVerticalBall;
    [SerializeField] private int StarterLaserCrossBall;
    [SerializeField] private int StarterInstaKillBall;
    [SerializeField] private int StarterFireBall;
    [SerializeField] private int StarterBombBall;
    [SerializeField] private int StarterPoisonBall;
    [SerializeField] private int StarterBlackHoleBall;
    public int PlayerBallsAmount { private set; get; }
    public bool IsBallAmountChanged;

    private void Awake()
    {
        Instance = this;
        EventManager.LevelStarted += UpdateBallsValues;
        EventManager.UpgradeStats += UpdateBallsValues;

        //UpdateBallsValues();
        IsBallAmountChanged = false;
    }

    private void UpdateBallsValues()
    {
        startBallsAmount = (int)HeroStats.StarterBalls;

        PlayerBalls = new List<AbstractBall>(startBallsAmount);
        SpawnNewBall(startBallsAmount, BallsTypeEnum.Ball);

        StarterRocketBall = (int)HeroStats.StarterRocketBall;
        StarterIceBall = (int)HeroStats.StarterIceBall;
        StarterLaserHorizontalBall = (int)HeroStats.StarterLaserHorizontalBall;
        StarterLaserVerticalBall = (int)HeroStats.StarterLaserVerticalBall;
        StarterLaserCrossBall = (int)HeroStats.StarterLaserCrossBall;
        StarterInstaKillBall = (int)HeroStats.StarterInstaKillBall;
        StarterFireBall = (int)HeroStats.StarterFireBall;
        StarterBombBall = (int)HeroStats.StarterBombBall;
        StarterPoisonBall = (int)HeroStats.StarterPoisonBall;
        StarterBlackHoleBall = (int)HeroStats.StarterBlackHoleBall;
        SpawnNewBall(StarterRocketBall, BallsTypeEnum.RocketBall);
        SpawnNewBall(StarterIceBall, BallsTypeEnum.IceBall);
        SpawnNewBall(StarterLaserHorizontalBall, BallsTypeEnum.LaserHorizontalBall);
        SpawnNewBall(StarterLaserVerticalBall, BallsTypeEnum.LaserVerticalBall);
        SpawnNewBall(StarterLaserCrossBall, BallsTypeEnum.LaserCrossBall);
        SpawnNewBall(StarterInstaKillBall, BallsTypeEnum.InstaKillBall);
        SpawnNewBall(StarterFireBall, BallsTypeEnum.FireBall);
        SpawnNewBall(StarterBombBall, BallsTypeEnum.BombBall);
        SpawnNewBall(StarterPoisonBall, BallsTypeEnum.PoisonBall);
        SpawnNewBall(StarterBlackHoleBall, BallsTypeEnum.BlackHoleBall);

        PlayerBallsAmount = PlayerBalls.Count;
    }

    private void OnDestroy()
    {
        EventManager.LevelStarted -= UpdateBallsValues;
        EventManager.UpgradeStats -= UpdateBallsValues;
    }

    public void SpawnNewBall(int ballsToAddAmount, BallsTypeEnum ballsType)
    {
        for (int i = 0; i < ballsToAddAmount; i++)
        {
            AddBallToList(ballsType);
        }
    }

    public void SetSpecialAttack(BallSO _specialBall)
    {
        //  Debug.Log("SetSpecialAttack ---> " + _specialBall.name);
        AddBallToList(_specialBall.ballsType);
    }

    public void AddBallToTheBeginning(BallsTypeEnum ballsType)
    {
        AddBallToList(0, ballsType);
    }

    public void SavePlayerBallsAmount()
    {
        PlayerBallsAmount = PlayerBalls.Count;
    }

    public void AddBallToList(BallsTypeEnum ballsType)
    {
        m_BallPrefab = Resources.Load<GameObject>(ballsType.ToString()).GetComponent<AbstractBall>();
        PlayerBalls.Add(Instantiate(m_BallPrefab, transform.parent, false));
        PlayerBalls[PlayerBalls.Count - 1].transform.localPosition = transform.localPosition;
        PlayerBalls[PlayerBalls.Count - 1].transform.localScale = transform.localScale;
        PlayerBalls[PlayerBalls.Count - 1].Disable();
        SavePlayerBallsAmount();
    }

    public void AddBallToList(int ballOrderInList, BallsTypeEnum ballsType)
    {
        m_BallPrefab = Resources.Load<GameObject>(ballsType.ToString()).GetComponent<AbstractBall>();
        PlayerBalls.Insert(ballOrderInList, Instantiate(m_BallPrefab, transform.parent, false));
        PlayerBalls[PlayerBalls.Count - 1].transform.localPosition = transform.localPosition;
        PlayerBalls[PlayerBalls.Count - 1].transform.localScale = transform.localScale;
        PlayerBalls[PlayerBalls.Count - 1].Disable();
        SavePlayerBallsAmount();
    }

    public void ReplaceBallInList(BallsTypeEnum replaceableBall, BallsTypeEnum newBallType)
    {
        int ballIndex = GetIndexByBallTypeInList(replaceableBall);
        //  Debug.Log("ballIndex is -> " + ballIndex);
        m_BallPrefab = Resources.Load<GameObject>(newBallType.ToString()).GetComponent<AbstractBall>();

        PlayerBalls[ballIndex].DestroyAfterTime();
        PlayerBalls.Remove(PlayerBalls[ballIndex]);

        AddBallToList(ballIndex, newBallType);
    }

    private int GetIndexByBallTypeInList(BallsTypeEnum ballType)
    {
        for (int i = 0; i < PlayerBalls.Count; i++)
        {
            // Debug.Log("Balls names are -> " + PlayerBalls[i].name);
            //   if (PlayerBalls[i].name.Contains(ballType.ToString()))
            if (PlayerBalls[i].name == ballType.ToString() + "(Clone)")
            {
                // Debug.Log("Return index is -> " + i);
                return i;
            }
        }

        return -1;
    }

    public AbstractBall GetFirstBallInList()
    {
        // Debug.Log("GetFirstBallInList -> " + PlayerBalls[0]);
        return PlayerBalls[0];
    }

    public AbstractBall GetBallByBallTypeInList(BallsTypeEnum ballsType)
    {
        foreach (AbstractBall ball in PlayerBalls)
        {
            if (ball.name.Equals(ballsType.ToString() + "(Clone)"))
            {
                //Debug.Log("GetBallByBallTypeInList  -> " + ball.name);
                return ball;
            }
        }

        return null;
    }
    
    public int CountBallByBallTypeInList(BallsTypeEnum ballsType)
    {
        Debug.Log("startBallsAmount " + startBallsAmount + " PlayerBallsAmount " + PlayerBallsAmount);
        int count = 0;
        foreach (AbstractBall ball in PlayerBalls)
        {
            Debug.Log("GetBallByBallTypeInList  -> " + ball.name);
            if (ball.name.Equals(ballsType.ToString() + "(Clone)"))
            {
                count++;
            }
        }

        return count;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            ReplaceBallInList(BallsTypeEnum.Ball, BallsTypeEnum.InstaKillBall);
            GetFirstBallInList();
            GetBallByBallTypeInList(BallsTypeEnum.Ball);
        }
    }

    public void IncreaseBallsAmountFromOutSide(int amount)
    {
        PlayerBallsAmount += amount;
    }

    public void ClearStatsToDefault()
    {
        DestroyBallsOnScene();
        
        startBallsAmount = (int)HeroStats.GetStats(HeroStats.HeroStatsEnum.StarterBalls);
        
        PlayerBalls = new List<AbstractBall>(startBallsAmount);
        SpawnNewBall(startBallsAmount, BallsTypeEnum.Ball);
        PlayerBallsAmount = PlayerBalls.Count;
    }

    private void DestroyBallsOnScene()
    {
        if (PlayerBalls != null)
        {
            foreach (var ball in PlayerBalls)
            {
                Destroy(ball);
            }
        }
    }
}

public enum BallsTypeEnum
{
    Ball,
    RocketBall,
    IceBall,
    RocketClone,
    LaserHorizontalBall,
    LaserVerticalBall,
    LaserCrossBall,
    InstaKillBall,
    FireBall,
    BombBall,
    PoisonBall,
    BlackHoleBall
}