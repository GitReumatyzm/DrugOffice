using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToTheNextScene : MonoBehaviour, iInteractable 
{
    public Animator elevatorAnim1;
    public Animator elevatorAnim2;
    private string elevatorDoorClose1 = "elevatorDoorCloseAnim";
    private string elevatorDoorClose2 = "elevatorDoorCloseAnim1";
    public elevatorOpening elevatorDoorOpeningScript;
    public void Interact()
    {
        if (elevatorDoorOpeningScript.isElevatorDoorOpened)
        {
            elevatorAnim1.Play(elevatorDoorClose1, 0, 0f);
            elevatorAnim2.Play(elevatorDoorClose2, 0, 0f);
        }
        StartCoroutine(teleportAferDelay());
    }
    IEnumerator teleportAferDelay(float time = 5f)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }
}
