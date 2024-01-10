using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Scripting;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
public class TestPuzzle : MonoBehaviour
{
    PlayerInputAction input;

    public static Action OnpuzzleEnd;
    [SerializeField] TextMeshProUGUI inputText;
    [SerializeField] Image fillImage;
    private float fillAmount = 1f;
    private float fillTime = 2f;
    private float timer = 0;
    private bool isPuzzleCompleted;

    [SerializeField] char[] chars;
    private int currentIndex = 0;
    private Coroutine InputTimerCoroutine;
    private bool onInputCheck;


    private void Awake()
    {
        input = new PlayerInputAction();
    }

    private void OnEnable()
    {
        input.Enable();
        Keyboard.current.onTextInput += GetChar;
        PlayerSearch.OnResetAllPuzzle += ResetPuzzle;

        timer = fillTime;
        currentIndex = 0;
        inputText.text = chars[currentIndex].ToString();
        ResetTimer();
        InputTimerCoroutine = StartCoroutine(CheckInputTimer());


    }

    private void OnDisable()
    {
        input.Disable();
        Keyboard.current.onTextInput -= GetChar;
        PlayerSearch.OnResetAllPuzzle -= ResetPuzzle;
    }

    private void Start()
    {
        timer = fillTime;
        inputText.text = chars[currentIndex].ToString();
        ResetTimer();
        //InputTimerCoroutine = StartCoroutine(CheckInputTimer());

    }


    private void Update()
    {
        timer -= Time.deltaTime;
        fillAmount = timer / fillTime;
        fillImage.fillAmount = fillAmount;
    }

    IEnumerator CheckInputTimer()
    {
        Debug.Log("Start Coroutine");
        onInputCheck = true;
        yield return new WaitForSeconds(fillTime);
        OnFailPuzzle();
    }
    private void CheckInput(char c)
    {
        if (c == chars[currentIndex])
        {
            Debug.Log("Right");
            currentIndex++;
            if (currentIndex < chars.Length)
            {
                onInputCheck = false;
                StopCoroutine(InputTimerCoroutine);
                ResetTimer();
                inputText.text = chars[currentIndex].ToString();
                InputTimerCoroutine = StartCoroutine(CheckInputTimer());
            }
            else
            {
                OnEndPuzzle();
            }

        }
        else
        {
            OnFailPuzzle();
            Debug.Log("Failed");
        }
    }


    private void ResetTimer()
    {
        fillAmount = 1f;
        timer = fillTime;
    }
    private void ResetPuzzle()
    {
        isPuzzleCompleted = false;
        ResetTimer();
        currentIndex = 0;

    }

    private void OnEndPuzzle()
    {
        Debug.Log("Puzzle Completed");
        onInputCheck = false;
        isPuzzleCompleted = true;
        OnpuzzleEnd?.Invoke();
    }
    private void OnFailPuzzle()
    {
        Debug.Log("Make Noise");
        onInputCheck = false;
        OnpuzzleEnd?.Invoke();
    }

    private void GetChar(char a)
    {
        if (onInputCheck)
        {
            Debug.Log("Input Char = " + a);
            CheckInput(a);
        }
    }

}
