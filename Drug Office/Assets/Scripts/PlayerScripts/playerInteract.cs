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
            Debug.Log("klik");
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                Debug.Log("sss");
                if (hitInfo.collider.gameObject.TryGetComponent(out iInteractable interactObj))
                {
                    Debug.Log("eee");
                    interactObj.Interact();
                }
            }
        }
    }
}


