using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerOn : MonoBehaviour, iInteractable
{
    //public GameObject InstructionsText;
    [SerializeField] GameObject computerCanvas;
    public void Interact()
    {
        computerCanvas.SetActive(true);
        //InstructionsText.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        FirstPersonCamera.mouseSesnsitivity = 0f;
    }
}
