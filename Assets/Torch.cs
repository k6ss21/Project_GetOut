using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Torch : MonoBehaviour
{

    [Header("Bright Light Settings")]
    [Space(10)]
    [SerializeField] float brightLightRange;
    [SerializeField][Range(1, 179)] float brightLightAngle;
    [Space(10)]
    [Header("Dim Light Settings")]
    [Space(10)]
    [SerializeField] float dimLightRange;
    [SerializeField][Range(1, 179)] float dimLightAngle;

    [Space(10)]

    PlayerInputAction input;
    [SerializeField] Light torch;
    bool isTorchActive;
    bool usingDimTorch;

    [Header("Battery Settings")]
    [Space(10)]
    public float batteryLevelValue = 100;
    float batteryDrainMulti = 1f;

    [SerializeField] float dimMulti = .7f;

    [SerializeField] float brightMulti = 1f;

    public Animator animator;

    private void Awake()
    {
        input = new PlayerInputAction();
    }
    private void OnEnable()
    {
        input.Enable();
        Battery.OnBatteryUse += AddBatteryLevel;
    }

    private void OnDisable()
    {
        input.Disable();
        Battery.OnBatteryUse -= AddBatteryLevel;
    }

    private void Start()
    {
        isTorchActive = true;
        usingDimTorch = true;
        // brightTorch.SetActive(!usingDimTorch);
        // dimTorch.SetActive(usingDimTorch);
        SetDimTorchValue();
        SetDrainMuliti();
    }

    private void Update()
    {
        BatteryDrain();
        if (batteryLevelValue < 5 && batteryLevelValue > 1)
        {
            animator.SetBool("IsLowbattery", true);
        }
        else if (batteryLevelValue >= 5)
        {
            animator.SetBool("IsLowbattery", false);


        }
        else if (batteryLevelValue <= 0)
        {
            if (isTorchActive)
            {
                animator.SetBool("IsLowbattery", false);
                isTorchActive = false;
                torch.gameObject.SetActive(false);
            }
        }
        if (input.Player.Torch.WasPerformedThisFrame())
        {
            TorchSwitch();
        }
    }

    void TorchSwitch()
    {
        usingDimTorch = !usingDimTorch;
        // brightTorch.SetActive(!usingDimTorch);
        // dimTorch.SetActive(usingDimTorch);
        if (usingDimTorch)
        {
            SetDimTorchValue();
        }
        else
        {
            SetBrightTorchValue();
        }
        SetDrainMuliti();
    }

    void SetBrightTorchValue()
    {
        torch.range = brightLightRange;
        torch.spotAngle = brightLightAngle;
    }
    void SetDimTorchValue()
    {
        torch.range = dimLightRange;
        torch.spotAngle = dimLightAngle;
    }

    void SetDrainMuliti()
    {
        if (usingDimTorch)
        {
            batteryDrainMulti = dimMulti;

        }
        else
        {
            batteryDrainMulti = brightMulti;
        }
    }

    void BatteryDrain()
    {
        batteryLevelValue -= batteryDrainMulti * Time.deltaTime;
        if (batteryLevelValue <= 0)
        {
            batteryLevelValue = 0;
         }
    }
    void AddBatteryLevel(float value)
    {
        batteryLevelValue += value;
        if (batteryLevelValue > 0)
        {
            isTorchActive = true;
            torch.gameObject.SetActive(true);
        }
    }

}
