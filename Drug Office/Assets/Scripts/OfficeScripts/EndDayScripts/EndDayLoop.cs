using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndDayLoop : MonoBehaviour
{
    public List<TextMeshProUGUI> taskTexts = new List<TextMeshProUGUI>();
    public GameObject endDayText;
    public BoxCollider elevatorButtonCollider;
    [SerializeField] Animator elevatorAnim1;
    [SerializeField] Animator elevatorAnim2;
    private string elevatorDoorOpen1 = "elevatorDoorOpenAnim";
    private string elevatorDoorOpen2 = "elevatorDoorOpenAnim1";

    public void Update()
    {
        bool isDayEnded = true;
        foreach (TextMeshProUGUI tTexts in taskTexts)
        {
            if (tTexts.enabled)
            {
                isDayEnded = false;
                break;
            }

        }

        if (isDayEnded)
        {
            elevatorAnim1.CrossFade(elevatorDoorOpen1, 0f);
            elevatorAnim2.CrossFade(elevatorDoorOpen2, 0f);
            elevatorButtonCollider.enabled = true;
            endDayText.SetActive(true);
        }

    }
}
