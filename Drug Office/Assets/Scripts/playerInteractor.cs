using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractor : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("KLIK");
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out iInteractable interactObj))
                {
                    interactObj.Interact();
                    Debug.Log("goin up");
                }
            }
        }
    }
}