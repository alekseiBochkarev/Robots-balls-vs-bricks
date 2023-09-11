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
    private int starterBalls;
    [SerializeField] private int starterRocketBall;
    [SerializeField] private int starterIceBall;
    [SerializeField] private int starterLaserHorizontalBall;
    [SerializeField] private int starterLaserVerticalBall;
    [SerializeField] private int starterLaserCrossBall;
    [SerializeField] private int starterInstaKillBall;
    [SerializeField] private int starterFireBall;
    [SerializeField] private int starterBombBall;
    [SerializeField] private int starterPoisonBall;
    [SerializeField] private int starterBlackHoleBall;
    public int PlayerBallsAmount { private set; get; }
    public bool IsBallAmountChanged;

    private void Awake()
    {
        Instance = this;
        EventManager.LevelStarted += UpdateBallsValues;
        EventManager.UpgradeStats += UpdateBallsValues;
        EventManager.SkinChanged += UpdateBallsValues;
        EventManager.UpgradeAttackPowerStat += UpdateBallsValues;
        EventManager.LevelStarted += SpawnNewBallsOnStart;
        PlayerBalls = new List<AbstractBall>(starterBalls);
        //UpdateBallsValues();
        IsBallAmountChanged = false;
    }

    private void UpdateBallsValues()
    {
        starterBalls = (int)HeroStats.StarterBalls;
        //PlayerBalls = new List<AbstractBall>(startBallsAmount);
        //TODO когда будем добовлять стартовые шары других типов нужно либо подобное проделать для них, либо переписывать

        starterRocketBall = (int)HeroStats.StarterRocketBall;
        starterIceBall = (int)HeroStats.StarterIceBall;
        starterLaserHorizontalBall = (int)HeroStats.StarterLaserHorizontalBall;
        starterLaserVerticalBall = (int)HeroStats.StarterLaserVerticalBall;
        starterLaserCrossBall = (int)HeroStats.StarterLaserCrossBall;
        starterInstaKillBall = (int)HeroStats.StarterInstaKillBall;
        starterFireBall = (int)HeroStats.StarterFireBall;
        starterBombBall = (int)HeroStats.StarterBombBall;
        starterPoisonBall = (int)HeroStats.StarterPoisonBall;
        starterBlackHoleBall = (int)HeroStats.StarterBlackHoleBall;       
    }

    private void OnDestroy()
    {
        EventManager.LevelStarted -= UpdateBallsValues;
        EventManager.UpgradeStats -= UpdateBallsValues;
        EventManager.SkinChanged -= UpdateBallsValues;
        EventManager.UpgradeAttackPowerStat -= UpdateBallsValues;
        EventManager.LevelStarted -= SpawnNewBallsOnStart;
    }

    private void SpawnNewBallsOnStart()
    {
        SpawnNewBall(starterBalls, BallsTypeEnum.Ball);
        SpawnNewBall(starterRocketBall, BallsTypeEnum.RocketBall);
        SpawnNewBall(starterIceBall, BallsTypeEnum.IceBall);
        SpawnNewBall(starterLaserHorizontalBall, BallsTypeEnum.LaserHorizontalBall);
        SpawnNewBall(starterLaserVerticalBall, BallsTypeEnum.LaserVerticalBall);
        SpawnNewBall(starterLaserCrossBall, BallsTypeEnum.LaserCrossBall);
        SpawnNewBall(starterInstaKillBall, BallsTypeEnum.InstaKillBall);
        SpawnNewBall(starterFireBall, BallsTypeEnum.FireBall);
        SpawnNewBall(starterBombBall, BallsTypeEnum.BombBall);
        SpawnNewBall(starterPoisonBall, BallsTypeEnum.PoisonBall);
        SpawnNewBall(starterBlackHoleBall, BallsTypeEnum.BlackHoleBall);

        PlayerBallsAmount = PlayerBalls.Count;
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
        if (PlayerBalls is not null)
        {
            m_BallPrefab = Resources.Load<GameObject>(ballsType.ToString()).GetComponent<AbstractBall>();
            PlayerBalls.Add(Instantiate(m_BallPrefab, transform.parent, false));
            PlayerBalls[PlayerBalls.Count - 1].transform.localPosition = transform.localPosition;
            PlayerBalls[PlayerBalls.Count - 1].transform.localScale = transform.localScale;
            PlayerBalls[PlayerBalls.Count - 1].Disable();
            SavePlayerBallsAmount();
        }
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
        Debug.Log("startBallsAmount " + starterBalls + " PlayerBallsAmount " + PlayerBallsAmount);
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
        
        starterBalls = (int)HeroStats.GetStats(HeroStats.HeroStatsEnum.StarterBalls);
        
        PlayerBalls = new List<AbstractBall>(starterBalls);
        SpawnNewBall(starterBalls, BallsTypeEnum.Ball);
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