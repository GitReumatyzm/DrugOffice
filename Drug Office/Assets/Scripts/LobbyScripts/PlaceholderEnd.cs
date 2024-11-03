using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderEnd : MonoBehaviour
{
 
    public GameObject endImage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            endImage.SetActive(true);

        }
    }
}
