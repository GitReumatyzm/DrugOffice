using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndDayLoop : MonoBehaviour
{
    public List<TextMeshProUGUI> taskTexts = new List<TextMeshProUGUI>();
    public GameObject endDayText;
    public BoxCollider elevatorButtonCollider;

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
            elevatorButtonCollider.enabled = true;
            endDayText.SetActive(true);
        }

    }
}
