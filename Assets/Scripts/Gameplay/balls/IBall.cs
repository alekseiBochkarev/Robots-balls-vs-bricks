using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBall 
{
    int GetAttackPower { get; }
    int GetDamageTextFontSize { get; }
    Color GetDamageTextColor { get; }

}
