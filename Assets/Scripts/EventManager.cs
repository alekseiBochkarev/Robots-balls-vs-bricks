using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action BrickDestroyed;
    public static event Action<int> HealthChanged;

    public static void OnBrickDestroyed() 
    {
        BrickDestroyed?.Invoke();
    }

    public static void OnHealthChanged(int health) 
    {
        HealthChanged?.Invoke(health);
    }
}