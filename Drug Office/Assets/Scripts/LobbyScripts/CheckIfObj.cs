using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfObj : MonoBehaviour
{
    [SerializeField] BoxCollider bloodStainCollider;
    [SerializeField] BoxCollider blockinCollider;
    [SerializeField] GameObject endDayCollider;
    void Update()
    {
        if(bloodStainCollider.enabled == false)
        {
            blockinCollider.enabled = false;
            endDayCollider.SetActive(true);
        }
    }
}
