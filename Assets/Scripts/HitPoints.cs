using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    public int MainBallPoints => _pointsPerHitMainBall;
    public int ExtraBallPoints => _pointsPerHitExtraBall;

    private int _pointsPerHitMainBall = 10;
    private int _pointsPerHitExtraBall = 100;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MainBall"))
        {
            GameManager.GameScore += _pointsPerHitMainBall;
        }
        if (collision.gameObject.CompareTag("ExtraBall"))
        {
            GameManager.GameScore += _pointsPerHitExtraBall;
        }
    }
}
