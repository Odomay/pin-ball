using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public Button StartButton;
    public Button ExitButton;
    public AudioClip MenuClip;

    private void Start()
    {
        StartButton.onClick.AddListener(StartGame);
        ExitButton.onClick.AddListener(ExitGame);
        SoundManager.Instance.PlayMainSound(MenuClip);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundManager.Instance.PlaySound(SoundType.ButtonType);
    }

    private void ExitGame()
    {
        Application.Quit();
        SoundManager.Instance.PlaySound(SoundType.ButtonType);
    }
}
