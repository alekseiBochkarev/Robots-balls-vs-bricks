using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryAnimator : MonoBehaviour
{
    private const string HAS_ENERGY = "HasEnergy";

    [SerializeField] private BatteryEnergy batteryEnergy;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(HAS_ENERGY, batteryEnergy.HasBatteryEnergy());
    }
}
