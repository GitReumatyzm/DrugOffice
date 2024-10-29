using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialaogueTrigger : MonoBehaviour
{
    public Dialaogue dialaogue;
    public DialaogueManagerScript dialaogueScript;
    [SerializeField] bool isRepeatable;
    [SerializeField] bool isWantStop;
    public bool isCameraChanged;
    public GameObject playerCamera;
    public GameObject cutsceneCamera;
    public GameObject tasksCanvas;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<DialaogueManagerScript>().StartDialaogue(dialaogue);

            if (isRepeatable == false)
            {
                this.GetComponent<BoxCollider>().enabled = false;
            }

            if (isWantStop == true)
            {
                PlayerMovement.playerSpeed = PlayerMovement.playerFreeze;
            }
            if (isCameraChanged == true)
            {
                playerCamera.SetActive(false);
                cutsceneCamera.SetActive(true);
                tasksCanvas.SetActive(false);
                isCameraChanged = false;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (isWantStop == false)
        {
            dialaogueScript.speechText.enabled = false;
            dialaogueScript.npcNameText.enabled = false;
        }
    }

}
