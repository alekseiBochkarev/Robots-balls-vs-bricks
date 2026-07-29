using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Guns
{
    public class GunPanel : MonoBehaviour
    {
        public Text BallCountText;
        public Text RocketBallCountText;
        public Text IceBallCountText;
        public Text LaserHorizontalBallCountText;
        public Text LaserVerticalBallCountText;
        public Text LaserCrossBallCountText;
        public Text InstaKillBallCountText;
        public Text FireBallCountText;
        public Text BombBallCountText;
        public Text PoisonBallCountText;
        public Text BlackHoleBallCountText;

        private void OnEnable()
        {
            BallCountText.text = Balls.Instance.CountBallByBallTypeInList(BallsTypeEnum.Ball).ToString();
            RocketBallCountText.text = Balls.Instance.CountBallByBallTypeInList(BallsTypeEnum.RocketBall).ToString();
            IceBallCountText.text = Balls.Instance.CountBallByBallTypeInList(BallsTypeEnum.IceBall).ToString();
            LaserHorizontalBallCountText.text =
                Balls.Instance.CountBallByBallTypeInList(BallsTypeEnum.LaserHorizontalBall).ToString();
            LaserVerticalBallCountText.text = Balls.Instance.CountBallByBallTypeInList(BallsTypeEnum.LaserVerticalBall).ToString();
            LaserCrossBallCountText.text = Balls.Instance.CountBallByBallTypeInList(BallsTypeEnum.LaserCrossBall).ToString();
            InstaKillBallCountText.text = Balls.Instance.CountBallByBallTypeInList(BallsTypeEnum.InstaKillBall).ToString();
            FireBallCountText.text = Balls.Instance.CountBallByBallTypeInList(BallsTypeEnum.FireBall).ToString();
            BombBallCountText.text = Balls.Instance.CountBallByBallTypeInList(BallsTypeEnum.BombBall).ToString();
            PoisonBallCountText.text = Balls.Instance.CountBallByBallTypeInList(BallsTypeEnum.PoisonBall).ToString();
            BlackHoleBallCountText.text = Balls.Instance.CountBallByBallTypeInList(BallsTypeEnum.BlackHoleBall).ToString();
        }
        
    }
    
}
