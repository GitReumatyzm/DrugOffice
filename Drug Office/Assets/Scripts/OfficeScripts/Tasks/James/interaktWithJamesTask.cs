using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaktWithJamesTask : MonoBehaviour, iInteractable
{
    public GameObject jamesCanvas;
    public void Interact()
    {
       jamesCanvas.SetActive(true);
       Cursor.lockState = CursorLockMode.None;
    }
}
