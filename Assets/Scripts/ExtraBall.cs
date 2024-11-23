using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBall : MonoBehaviour
{
    public List<GameObject> ExtraBalls = new List<GameObject>();
    public List<Transform> BallSpawnPositions = new List<Transform>();

    private GameObject _extraBall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainBall"))
        {
            if (_extraBall == null)
            {
                _extraBall = Instantiate(ExtraBalls[Random.Range(0, ExtraBalls.Count)]);
                _extraBall.transform.position = BallSpawnPositions[Random.Range(0, BallSpawnPositions.Count)].position;

            }
        }
    }
}
