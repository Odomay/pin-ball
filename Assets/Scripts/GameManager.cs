using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int GameScore = 0;
    public static int BallCount = 5;
    public TMP_Text BallCountText;
    public TMP_Text HitPointsText;

    [Header("PausePanelLogic")]
    public Button ResumeButton;
    public Button ExitButton;
    public Button PauseButton;
    public GameObject PausePanel;

    private void Start()
    {
        ResumeButton.onClick.AddListener(ResumeGame);
        ExitButton.onClick.AddListener(ExitGame);
        PauseButton.onClick.AddListener(PauseGame);
    }

    private void Update()
    {
        BallCountText.text = $"Balls Count: {BallCount:D2}";
        HitPointsText.text = $"{GameScore}";
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        PauseButton.interactable = true;
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        PauseButton.interactable = false;
    }
   
}
