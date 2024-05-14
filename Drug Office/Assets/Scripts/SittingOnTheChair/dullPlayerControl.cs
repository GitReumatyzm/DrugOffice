using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dullPlayerControl : MonoBehaviour
{
    public SittingOnTheChair sittingOnChairScript;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            sittingOnChairScript.isSitting = false;
            sittingOnChairScript.player.SetActive(true);
            sittingOnChairScript.dullPlayer.SetActive(false);
            sittingOnChairScript.computerCollider.enabled = false;
            sittingOnChairScript.infoCollider.SetActive(false);

        }

    }
}
