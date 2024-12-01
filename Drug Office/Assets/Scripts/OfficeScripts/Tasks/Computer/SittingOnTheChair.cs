using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingOnTheChair : MonoBehaviour, iInteractable
{
    public GameObject player;
    public GameObject dullPlayer;
    public BoxCollider computerCollider;
    //public GameObject infoCollider;
    public bool isSitting = false;
    public DialaogueManagerScript dialaogueManager;
    public void Interact()
    {
        //if (dialaogueManager.isQActive)
      //  {
            if (!isSitting)
            {
                isSitting = true;
                player.SetActive(false);
                dullPlayer.SetActive(true);
                computerCollider.enabled = true;
                //infoCollider.SetActive(false)
            }
      //  }

    }
    public void StandUp()
    {
            isSitting = false;
            player.SetActive(true);
            dullPlayer.SetActive(false);
            computerCollider.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            FirstPersonCamera.mouseSesnsitivity = 750f;

    }

}
