using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveComputer : MonoBehaviour
{
    public GameObject computerPanel;

    public void QuitComputer()
    {
        Cursor.lockState = CursorLockMode.Locked;
        computerPanel.SetActive(false);
        PlayerMovement.playerSpeed = 10f;
        FirstPersonCamera.mouseSesnsitivity = 1000f;

        if (computerPanel == null)
        {
            foreach (Transform child in computerPanel.transform)
            {
                child.gameObject.SetActive(false);
            }
        }

    }
}
