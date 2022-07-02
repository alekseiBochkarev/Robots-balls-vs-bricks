using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAttack : MonoBehaviour, AttackBehaviour
{
    public void SpecialAttack()
    {
        Debug.Log("special attack - No Attack");
    }
}
