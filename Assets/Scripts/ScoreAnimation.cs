using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreAnimation : MonoBehaviour
{
    private TMP_Text _scoreAnimationText;
    private Animator _animator;

    private void Awake()
    {
        _scoreAnimationText = GetComponent<TextMeshProUGUI>();
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation(int points)
    {
        _scoreAnimationText.text = $"+{points}";
        _animator.SetTrigger("Play");
    }
}