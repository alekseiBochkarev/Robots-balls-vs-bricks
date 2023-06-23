using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Guns
{
    public class GunPanel : MonoBehaviour
    {
        public TMP_Text BallCountText;
        public TMP_Text RocketBallCountText;
        public TMP_Text IceBallCountText;
        public TMP_Text LaserHorizontalBallCountText;
        public TMP_Text LaserVerticalBallCountText;
        public TMP_Text LaserCrossBallCountText;
        public TMP_Text InstaKillBallCountText;
        public TMP_Text FireBallCountText;
        public TMP_Text BombBallCountText;
        public TMP_Text PoisonBallCountText;
        public TMP_Text BlackHoleBallCountText;

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