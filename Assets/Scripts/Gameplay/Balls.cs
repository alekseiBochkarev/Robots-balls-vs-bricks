using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public static Balls Instance;
    public static Dictionary<int, GameObject> ballsInScene; 
    private AbstractBall m_BallPrefab;
    public List<AbstractBall> PlayerBalls {private set; get; } 
    [SerializeField] private int startBallsAmount = 1;
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
        // int ballIndex = GetIndexByBallTypeInList(replaceableBall);
        // Debug.Log("ballIndex is -> " + ballIndex);
        // m_BallPrefab = Resources.Load<GameObject>(newBallType.ToString()).GetComponent<AbstractBall>();
        // PlayerBalls[ballIndex] = Instantiate(m_BallPrefab, transform.parent, false);
        // PlayerBalls[PlayerBalls.Count - 1].transform.localPosition = transform.localPosition;
        // PlayerBalls[PlayerBalls.Count - 1].transform.localScale = transform.localScale;
        // PlayerBalls[PlayerBalls.Count - 1].Disable();
        // SavePlayerBallsAmount();

        
        int ballIndex = GetIndexByBallTypeInList(replaceableBall);
        Debug.Log("ballIndex is -> " + ballIndex);
        m_BallPrefab = Resources.Load<GameObject>(newBallType.ToString()).GetComponent<AbstractBall>();
        // need to delete ball on scene, not only in List of balls
        PlayerBalls.Remove(PlayerBalls[ballIndex]);
        AddBallToList(ballIndex, newBallType);
    }

    private int GetIndexByBallTypeInList(BallsTypeEnum ballType)
    {
        for (int i = 0; i < PlayerBalls.Count; i++)
        {
            Debug.Log("Balls names are -> " + PlayerBalls[i].name);
         //   if (PlayerBalls[i].name.Contains(ballType.ToString()))
            if (PlayerBalls[i].name == ballType.ToString() + "(Clone)")
            {
                Debug.Log("Return index is -> " + i);
                return i;
            }                
        }
        return -1;
    }
    public AbstractBall GetFirstBallInList()
    {
        Debug.Log("GetFirstBallInList -> " + PlayerBalls[0]);
        return PlayerBalls[0];
    }

    public AbstractBall GetBallByBallTypeInList(BallsTypeEnum ballsType)
    {
        foreach (AbstractBall ball in PlayerBalls)
        {
            if (ball.name.Contains(" " + ballsType.ToString())) 
            {
                Debug.Log("GetBallByBallTypeInList  -> " + ball.name);
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
}