using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public static Balls Instance;
    private AbstractBall m_BallPrefab;
    public List<AbstractBall> PlayerBalls {private set; get; } 
    [SerializeField] private int startBallsAmount = 5;
    public int PlayerBallsAmount {private set; get; }
    public bool IsBallAmountChanged;
    public enum BallsTypeEnum
    {
        Ball,
        RocketBall,
        RocketClone,
        LaserHorizontalBall,
        LaserVerticalBall,
        LaserCrossBall,
        InstaKillBall
    }

    // public Balls()
    // {
    //     Instance = this;
    //     PlayerBalls = new List<AbstractBall>(startBallsAmount);
    //     SpawnNewBall(startBallsAmount, BallsTypeEnum.Ball);
    //     PlayerBallsAmount = PlayerBalls.Count;
    //     IsBallAmountChanged = false;
    // }

    private void Start() 
    {
        Instance = this;
        PlayerBalls = new List<AbstractBall>(startBallsAmount);
        SpawnNewBall(startBallsAmount, BallsTypeEnum.Ball);
        PlayerBallsAmount = PlayerBalls.Count;
        IsBallAmountChanged = false;
    }

    // public void AddBall(BallsTypeEnum ballsType)
    // {
    //     IncreaseBallsAmountFromOutSide(1);
    //    // m_BallsAmount++;
    //    // m_BallsText.text = "x" + m_BallsAmount.ToString();
    //     AddBallToList(ballsType);
    // }

    public void SpawnNewBall(int ballsToAddAmount, BallsTypeEnum ballsType)
    {
        
        for (int i = 0; i < ballsToAddAmount; i++)
        {
            AddBallToList(ballsType);
        }
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

    public void AddBallToList (int ballOrderInList, BallsTypeEnum ballsType)
    {
        m_BallPrefab = Resources.Load<GameObject>(ballsType.ToString()).GetComponent<AbstractBall>();
        PlayerBalls.Insert(ballOrderInList, Instantiate(m_BallPrefab, transform.parent, false));
        PlayerBalls[PlayerBalls.Count - 1].transform.localPosition = transform.localPosition;
        PlayerBalls[PlayerBalls.Count - 1].transform.localScale = transform.localScale;
        PlayerBalls[PlayerBalls.Count - 1].Disable();
        SavePlayerBallsAmount();
    }

    // public AbstractBall GetFirstBallInList()
    // {
    //   //  return PlayerBalls.FindLastIndex();
    // }

    public void IncreaseBallsAmountFromOutSide(int amount)
    {
        PlayerBallsAmount += amount;
    }
}
