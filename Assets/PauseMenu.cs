using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public class PauseMenu : MonoBehaviour
{
    public static event Action OnResumeButtonPressed;
    public void ResumeButton()
    {
        OnResumeButtonPressed?.Invoke();
    }
    public void MainMenuButton()
    {
        Debug.Log("Open MainMenu");
    }
    public void SettingsButton()
    {
        Debug.Log("Open Settings");
    }
    public void ExitButton()
    {
        Application.Quit();
    }

}
