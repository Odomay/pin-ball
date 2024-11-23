using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float FlashDuration;
    public Color FlashColor;
    public float Intensity;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject flashLightObject = new GameObject("Flash");
        Light flashLight = flashLightObject.AddComponent<Light>();
        flashLight.color = FlashColor;
        flashLight.intensity = Intensity;
        flashLight.range = 5f;
        flashLight.type = LightType.Point;
        flashLightObject.transform.position = collision.contacts[0].point;
        Destroy(flashLightObject, FlashDuration);
    }
}
