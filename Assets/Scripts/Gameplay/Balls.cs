using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Balls : MonoBehaviour, IResetToDefaultValues
{
    public static Balls Instance;

    private HeroStats _heroStats;
    public static Dictionary<int, GameObject> ballsInScene;
    private AbstractBall m_BallPrefab;
    public List<AbstractBall> PlayerBalls { private set; get; }
    [SerializeField] private int startBallsAmount;
    public int PlayerBallsAmount { private set; get; }
    public bool IsBallAmountChanged;

    private void Awake()
    {
        Instance = this;

        _heroStats = new HeroStats();
        startBallsAmount = (int)_heroStats.StarterBalls;

        PlayerBalls = new List<AbstractBall>(startBallsAmount);
        SpawnNewBall(startBallsAmount, BallsTypeEnum.Ball);
        PlayerBallsAmount = PlayerBalls.Count;
        IsBallAmountChanged = false;
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
            if (ball.name.Contains(" " + ballsType.ToString()))
            {
                //Debug.Log("GetBallByBallTypeInList  -> " + ball.name);
                return ball;
            }
        }

        return null;
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
        
        startBallsAmount = (int)_heroStats.StarterBalls;
        
        PlayerBalls = new List<AbstractBall>(startBallsAmount);
        SpawnNewBall(startBallsAmount, BallsTypeEnum.Ball);
        PlayerBallsAmount = PlayerBalls.Count;
    }

    private void DestroyBallsOnScene()
    {
        foreach (var ball in PlayerBalls)
        {
            Destroy(ball);
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
    FireBall
}