using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorOpening : MonoBehaviour
{
    public Animator elevatorAnim1;
    public Animator elevatorAnim2;
    private string elevatorDoorOpen1 = "elevatorDoorOpenAnim";
    private string elevatorDoorOpen2 = "elevatorDoorOpenAnim1";
    public bool isElevatorDoorOpened = false;
    public float time = 3f;

    public void Start()
    {
        StartCoroutine(openingElevatorAfterDelay());
    }

    IEnumerator openingElevatorAfterDelay()
    {
        yield return new WaitForSeconds(time);
        elevatorAnim1.Play(elevatorDoorOpen1, 0, 0f);
        elevatorAnim2.Play(elevatorDoorOpen2, 0, 0f);
        isElevatorDoorOpened = true;
    }
}
