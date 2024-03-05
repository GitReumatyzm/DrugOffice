using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectInteract : MonoBehaviour, iInteractable
{
    public GameObject computerPanel;

    public void Interact()
    {
        computerPanel.SetActive(true);
        FirstPersonCamera.mouseSesnsitivity = 0f;
        Cursor.lockState = CursorLockMode.None;

        if(computerPanel != null)
        {
            foreach(Transform child in computerPanel.transform)
            {
                PlayerMovement.playerSpeed = 0f;
                child.gameObject.SetActive(true);
            }
        }
    }
}
