using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionsButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(ResumeButtonClick);
        mainMenuButton.onClick.AddListener(MainMenuButtonClick);
        optionsButton.onClick.AddListener(OptionsButtonClick);
    }

    private void Start()
    {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
        
        Hide();
    }

    private void GameManager_OnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void GameManager_OnGamePaused(object sender, EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ResumeButtonClick()
    {
        GameManager.Instance.TogglePauseGame();
    }

    private void MainMenuButtonClick()
    {
        Loader.Load(Loader.Scene.MainMenuScene);
    }

    private void OptionsButtonClick()
    {
        OptionsUI.Instance.Show();
    }
}
