using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDialaogueScript : MonoBehaviour
{
    public Dialaogue dialaogue;
    public DialaogueManagerScript dialaogueManager;
    public PlayerMovement playerMovementScript;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject pressTText;

    void Start()
    {
        StartCoroutine(DelayedDialogueStart());
    }

    private void Update()
    {
        playerMovementScript.SkippingDaialogue();
    }

    IEnumerator DelayedDialogueStart()
    {
        yield return null;

        if (dialaogueManager == null)
        {
            dialaogueManager = FindObjectOfType<DialaogueManagerScript>();
        }

        if (dialaogueManager != null)
        {
            dialaogueManager.StartDialaogue(dialaogue);
        }

    }
}
