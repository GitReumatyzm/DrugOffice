using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorOpen : MonoBehaviour, iInteractable
{
    public Animator elevatorAnim1;
    public Animator elevatorAnim2;
    private string elevatorDoorOpen1 = "elevatorDoorOpen";
    private string elevatorDoorOpen2 = "elevatorDoorOpen2";

    public void Interact()
    {
        elevatorAnim1.Play(elevatorDoorOpen1, 0, 0f);
        elevatorAnim2.Play(elevatorDoorOpen2, 0, 0f);
    }
}
