using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    void SetMaxHealth(int maxHealth);
    void HealUp(int healHealthUpAmount);
}
