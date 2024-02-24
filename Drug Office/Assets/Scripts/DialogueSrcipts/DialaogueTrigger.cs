using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialaogueTrigger : MonoBehaviour
{
    public Dialaogue dialaogue;
    [SerializeField] bool isRepeatable;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<DialaogueManagerScript>().StartDialaogue(dialaogue);

            if (isRepeatable == false)
            {
                this.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

}
