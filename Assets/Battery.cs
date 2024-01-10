using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public class Battery : MonoBehaviour, IUsableItem
{
    [SerializeField] float batteryRechargeAmount;
    public static event Action<float> OnBatteryUse;
    public void Use()
    {
        OnBatteryUse?.Invoke(batteryRechargeAmount);
        Debug.Log("Use Battery!!!!");
    }
}
