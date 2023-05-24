using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : AbstractBall
{
    private void Awake() {
      Init();
      attackBehaviour = gameObject.AddComponent<FireAttack>();
      //  afterCollisionBehaviour = new NoDestroy();
        damageTextColor = TextController.COLOR_BLACK;
        damageTextFontSize = TextController.FONT_SIZE_MAX;
    } 
}
