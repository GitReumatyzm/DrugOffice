using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dullPlayerControl : MonoBehaviour
{
    public SittingOnTheChair sittingOnChairScript;
    public GameObject tasks;
    public DialaogueManagerScript dialaogueManager;
    [SerializeField] GameObject boss;
    void Update()
    {
        if (dialaogueManager.isQActive)
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                sittingOnChairScript.isSitting = false;
                sittingOnChairScript.player.SetActive(true);
                sittingOnChairScript.dullPlayer.SetActive(false);
                sittingOnChairScript.computerCollider.enabled = false;
                //sittingOnChairScript.infoCollider.SetActive(false);
                tasks.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                boss.SetActive(false);
            }
        }

    }
}