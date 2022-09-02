using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    void SetMaxHealth(float maxHealth);
    void HealUp(float healHealthUpAmount);
}
