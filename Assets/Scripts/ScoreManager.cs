using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject AnimationScoreCanvasPrefab;

    public void ShowAnimation(int hitPoints, Vector3 hitPosition)
    {
        GameObject scoreCanvasInstance = Instantiate(AnimationScoreCanvasPrefab);

        ScoreAnimation scoreAnimation1 = scoreCanvasInstance.transform.GetChild(0).GetComponentInChildren<ScoreAnimation>();
        ScoreAnimation scoreAnimation2 = scoreCanvasInstance.transform.GetChild(1).GetComponentInChildren<ScoreAnimation>();
        //ScoreAnimation scoreAnimation = scoreCanvasInstance.GetComponentInChildren<ScoreAnimation>();

        if (scoreAnimation1 != null && scoreAnimation2 != null)
        {
            scoreCanvasInstance.transform.position = hitPosition;

            scoreAnimation1.PlayAnimation(hitPoints);
            scoreAnimation2.PlayAnimation(hitPoints);

        }
        Destroy(scoreCanvasInstance, 1f);
    }
}
