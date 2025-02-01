using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SoundType
{
    BallType,
    PlungerType,
    BamperType,
    ButtonType,
    FlipperType,
    GameHitsType,
    GameOverType,
    HPSoundType
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource AudioSource => _audioSource;

    [Header("Audio")]
    public AudioClip BallSound;
    public AudioClip PlungerSound;
    public AudioClip BamperSound;
    public AudioClip ButtonSound;
    public AudioClip FlipperSound;
    public AudioClip[] GameHits;
    public AudioClip GameOverSouhd;
    public AudioClip HPSound;

    private AudioSource _audioSource;
    private int _currentIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.BallType:
                _audioSource.PlayOneShot(BallSound, 0.1f);
                break;
            case SoundType.PlungerType:
                _audioSource.PlayOneShot(PlungerSound, 0.11f);
                break;
            case SoundType.BamperType:
                _audioSource.PlayOneShot(BamperSound, 0.5f);
                break;
            case SoundType.ButtonType:
                _audioSource.PlayOneShot(ButtonSound);
                break;
            case SoundType.FlipperType:
                _audioSource.PlayOneShot(FlipperSound);
                break;
            case SoundType.GameHitsType:
                PlayNextClip();
                break;
            case SoundType.GameOverType:
                _audioSource.PlayOneShot(GameOverSouhd);
                break;
            case SoundType.HPSoundType:
                _audioSource.PlayOneShot(HPSound);
                break;
        }
    }

    public void AudioSettings(Button muteButton, Button unmuteButton)
    {
        muteButton.onClick.AddListener(() =>_audioSource.mute = true);
        unmuteButton.onClick.AddListener(() =>_audioSource.mute = false);
    }


    private void PlayNextClip()
    {
        if (GameHits.Length > 0)
        {
            _currentIndex = Random.Range(0, GameHits.Length);
            _audioSource.clip = GameHits[_currentIndex];
            _audioSource.Play();
            _currentIndex = (_currentIndex + 1) % GameHits.Length;
            Invoke(nameof(PlayNextClip), _audioSource.clip.length);
        }
    }


    public void PlayMainSound(AudioClip menuClip)
    {
        _audioSource.clip = menuClip;
        _audioSource.volume = 0.1f;
        _audioSource.loop = true;
        _audioSource.Play();
    }
}
