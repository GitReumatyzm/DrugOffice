using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialaogueTrigger : MonoBehaviour
{
    public Dialaogue dialaogue;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<DialaogueManagerScript>().StartDialaogue(dialaogue);
        }
    }
}
