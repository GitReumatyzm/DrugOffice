using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface iInteractable
{
    public void Interact();
}
public class playerInteract : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out iInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}

