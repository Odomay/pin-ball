using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeFlashLightColor : MonoBehaviour
{
    public List <Light> FlashlightDecors;

    private void Start()
    {
        Light[] allLight = FindObjectsOfType<Light>();
        foreach (Light item in allLight)
        {
            if(item.TryGetComponent<ChangeFlashLightColor>(out var component))
            {
                FlashlightDecors.Add(item);
            }
        }
        StartCoroutine(ChangeLights());    
    }

    private IEnumerator ChangeLights()
    {
        while (true)
        {
            foreach (Light item in FlashlightDecors)
            {
                Color targetColor = Random.ColorHSV();
                float duration = 0.1f;
                float timeElapse = 0f;
                Color initialColor = item.color;

                while(timeElapse < duration)
                {
                    item.color = Color.Lerp(initialColor, targetColor, timeElapse / duration);
                    timeElapse += Time.deltaTime;
                    yield return null;
                }
                item.color = targetColor;
            }
        yield return new WaitForSeconds(0.5f);
        }
    }
}
