using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBall : AbstractBall
{
    private void Awake() {
      Init();
      attackBehaviour = gameObject.AddComponent<PoisonAttack>();
      //  afterCollisionBehaviour = new NoDestroy();
        damageTextColor = TextController.COLOR_GREEN;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    } 
}
