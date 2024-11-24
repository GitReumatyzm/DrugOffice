using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeninEle : MonoBehaviour
{
   
   public Animator elevatorAnim1;
    public Animator elevatorAnim2;
    private string elevatorDoorClose1 = "elevatorDoorOpenAnim";
    private string elevatorDoorClose2 = "elevatorDoorOpenAnim1";

    public void Start()
    {
        StartCoroutine(openAfter());
    }

    IEnumerator openAfter(float time = 3f)
    {
        yield return new WaitForSeconds(time);
        elevatorAnim1.Play(elevatorDoorClose1, 0, 0f);
        elevatorAnim2.Play(elevatorDoorClose2, 0, 0f);
    }
}