using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator LeftFlipperAnimator;
    public Animator RightFlipperAnimator;
    public Animator PlungerAnimator;

    private void Update()
    {
        ActivateFlipperAnimation();
        ActivatePlungerAnimation();
    }

    private void ActivateFlipperAnimation()
    {
        if (Input.GetKeyDown (KeyCode.Mouse0))
        {
            LeftFlipperAnimator.SetTrigger ("Push");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RightFlipperAnimator.SetTrigger("Push");
        }
    }

    private void ActivatePlungerAnimation()
    {
        AnimatorStateInfo stateInfo = PlungerAnimator.GetCurrentAnimatorStateInfo(0);
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (stateInfo.normalizedTime < 0)
            {
                PlungerAnimator.SetFloat("Direction", 0);
            }
            else
            {
                PlungerAnimator.SetFloat("Direction", -1);
            }
        }
        else
        {
            if (stateInfo.normalizedTime > 1)
            {
                PlungerAnimator.SetFloat("Direction", 0);
            }
            else
            {
                SoundManager.Instance.PlaySound(SoundType.PlungerType);
                PlungerAnimator.SetFloat("Direction", 1);
            }
        }
    }
}
