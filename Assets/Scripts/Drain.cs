using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drain : MonoBehaviour
{
    [SerializeField] private Transform _ballPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainBall"))
        {
          if (GameManager.BallCount > 0)
            {
                GameManager.BallCount--;
                Instantiate(other.gameObject).transform.position = _ballPosition.position;
            }
            
        }
        Destroy(other.gameObject);
    }
}
