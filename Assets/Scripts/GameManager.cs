using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int GameScore = 0;
    public static int BallCount = 5;
    public TMP_Text BallCountText;
    public TMP_Text HitPointsText;

    [Header("PausePanelLogic")]
    public Button ResumeButton;
    public Button ExitMenuButton;
    public Button PauseButton;
    public Button MuteButton;
    public Button unmuteButton;
    public GameObject PausePanel;

    private void Start()
    {
        ResumeButton.onClick.AddListener(ResumeGame);
        ExitMenuButton.onClick.AddListener(ExitMenu);
        PauseButton.onClick.AddListener(PauseGame);
        SoundManager.Instance.AudioSettings(MuteButton, unmuteButton);
        CheckPlayMusic();
        SoundManager.Instance.PlaySound(SoundType.GameHitsType);

    }

    private void Update()
    {
        BallCountText.text = $"Balls Count: {BallCount:D2}";
        HitPointsText.text = $"{GameScore}";
    }

    private void ExitMenu()
    {
        SceneManager.LoadScene(0);
        SoundManager.Instance.PlaySound(SoundType.ButtonType);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        PauseButton.interactable = true;
        SoundManager.Instance.PlaySound(SoundType.ButtonType);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        PauseButton.interactable = false;
        SoundManager.Instance.PlaySound(SoundType.ButtonType);
    }

    private void CheckPlayMusic()
    {
        if (SoundManager.Instance.AudioSource.isPlaying)
        {
            SoundManager.Instance.AudioSource.Stop();
        }
    }

}
