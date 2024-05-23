using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour, iInteractable
{
    [SerializeField] Animator doorAnim;
    [SerializeField] bool isOpened;
    [SerializeField] string openAnimation;
    [SerializeField] string closeAnimation;
    public void Interact()
    {
        if (!isOpened)
        {
            isOpened = true;
            doorAnim.Play(openAnimation, 0, 0.0f);
        }
        else if (isOpened)
        {
            isOpened = false;
            doorAnim.Play(closeAnimation, 0, 0.0f);
        }
    }
}
