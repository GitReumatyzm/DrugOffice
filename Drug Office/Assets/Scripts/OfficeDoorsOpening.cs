using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeDoorsOpening : MonoBehaviour
{
    [SerializeField] Animator doorAnimator;
    [SerializeField] string openAnimation;
    [SerializeField] string closeAnimation;
    [SerializeField] bool isOpen = false;
    [SerializeField] bool isCoroutineRunning = false;
    [SerializeField] BoxCollider otherBoxCollider; 
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isOpen && !isCoroutineRunning)
        {
            isOpen = true;
            otherBoxCollider.enabled = false;
            doorAnimator.Play(openAnimation, 0, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(isOpen && other.gameObject.CompareTag("Player") && !isCoroutineRunning)
        {
            isOpen = false;
            StartCoroutine(closeAfterDelay(3f));
        }
    }

    IEnumerator closeAfterDelay(float time)
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(time);
        doorAnimator.Play(closeAnimation, 0, 0.0f);
        yield return new WaitUntil(() => doorAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 &&
        doorAnimator.GetCurrentAnimatorStateInfo(0).IsName(closeAnimation));
        isCoroutineRunning = false;
    }
    
}
