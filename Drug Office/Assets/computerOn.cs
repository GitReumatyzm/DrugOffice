using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerOn : MonoBehaviour, iInteractable
{
    [SerializeField] GameObject computerCanvas;
    public void Interact()
    {
        computerCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        FirstPersonCamera.mouseSesnsitivity = 0f;
    }
}
