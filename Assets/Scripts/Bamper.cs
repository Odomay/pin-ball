using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bamper : MonoBehaviour
{
    private Vector3 _startScale;
    private Vector3 _targetScale;
    private float _scaleMultiplier = 1.2f;
    private Light _pointLight;

    private void Start()
    {
        _pointLight = GetComponentInChildren<Light>();
        _startScale = transform.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _pointLight.color = new Color(Random.value, Random.value, Random.value);
        IncreaseScale();
        SoundManager.Instance.PlaySound(SoundType.BamperType);
    }

    private void OnCollisionExit(Collision collision)
    {
        DecreaseScale();
    }

    private void IncreaseScale()
    {
        _targetScale = _startScale * _scaleMultiplier;
        transform.localScale = _targetScale;
    }

    private void DecreaseScale()
    {
        transform.localScale = _startScale;
    }
}
