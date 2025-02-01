using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandlerExtraBall : MonoBehaviour
{
    private ScoreManager _scoreManager;

    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        HitPoints points = collision.gameObject.GetComponent<HitPoints>();
        if (points != null)
        {
            int extraBallPoints = points.ExtraBallPoints;
            Vector3 hitPosition = collision.contacts[0].point;
            _scoreManager.ShowAnimation(extraBallPoints, hitPosition);
        }
    }
}
